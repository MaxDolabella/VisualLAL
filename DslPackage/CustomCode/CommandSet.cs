using Maxsys.VisualLAL.CustomCode.Utils;
using Microsoft.VisualStudio.Modeling.Diagrams;
using Microsoft.VisualStudio.Modeling.Shell;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace Maxsys.VisualLAL
{
    internal partial class VisualLALCommandSet
    {
        private Guid guidDiagramToolsMenuCmdSet = new Guid("9BE22312-4F7D-48BB-A5CB-2F0FA41597BB");
        private const int grpidDiagramToolsMenuGroup = 0x01001;
        private const int grpidSymbolToolsMenuGroup = 0x01002;

        private const int cmdidCollapseAllContextMenuCommand = 0x00001;
        private const int cmdidExpandAllContextMenuCommand = 0x00002;
        private const int cmdidAlignSymbolsContextMenuCommand = 0x00003;

        private const int cmdidFitSymbolsToContentContextMenuCommand = 0x00004;
        private const int cmdidFitSymbolsToDefaultContextMenuCommand = 0x00005;

        protected override IList<MenuCommand> GetMenuCommands()
        {
            // Get the list of generated commands.  
            IList<MenuCommand> commands = base.GetMenuCommands();
            
            // CollapseAll command:  
            DynamicStatusMenuCommand collapseAllContextMenuCommand =
              new DynamicStatusMenuCommand(
                new EventHandler(OnStatusCollapseAllContextMenuCommand),
                new EventHandler(OnMenuCollapseAllContextMenuCommand),
                new CommandID(guidDiagramToolsMenuCmdSet, cmdidCollapseAllContextMenuCommand));
            commands.Add(collapseAllContextMenuCommand);

            // collapseAll command:  
            DynamicStatusMenuCommand expandAllContextMenuCommand =
              new DynamicStatusMenuCommand(
                new EventHandler(OnStatusExpandAllContextMenuCommand),
                new EventHandler(OnMenuExpandAllContextMenuCommand),
                new CommandID(guidDiagramToolsMenuCmdSet, cmdidExpandAllContextMenuCommand));
            commands.Add(expandAllContextMenuCommand);

            // collapseAll command:  
            DynamicStatusMenuCommand alignSymbolsContextMenuCommand =
              new DynamicStatusMenuCommand(
                new EventHandler(OnStatusAlignSymbolsContextMenuCommand),
                new EventHandler(OnMenuAlignSymbolsContextMenuCommand),
                new CommandID(guidDiagramToolsMenuCmdSet, cmdidAlignSymbolsContextMenuCommand));
            commands.Add(alignSymbolsContextMenuCommand);

            // FitSymbolsToContent command:  
            DynamicStatusMenuCommand fitSymbolsToContentContextMenuCommand =
              new DynamicStatusMenuCommand(
                new EventHandler(OnStatusFitSymbolsToContentContextMenuCommand),
                new EventHandler(OnMenuFitSymbolsToContentContextMenuCommand),
                new CommandID(guidDiagramToolsMenuCmdSet, cmdidFitSymbolsToContentContextMenuCommand));
            commands.Add(fitSymbolsToContentContextMenuCommand);

            // FitSymbolsToDefault command:  
            DynamicStatusMenuCommand fitSymbolsToDefaultContextMenuCommand =
              new DynamicStatusMenuCommand(
                new EventHandler(OnStatusFitSymbolsToDefaultContextMenuCommand),
                new EventHandler(OnMenuFitSymbolsToDefaultContextMenuCommand),
                new CommandID(guidDiagramToolsMenuCmdSet, cmdidFitSymbolsToDefaultContextMenuCommand));
            commands.Add(fitSymbolsToDefaultContextMenuCommand);
            return commands;
        }

        

        #region CollapseAll
        // WHEN TO SHOW
        private void OnStatusCollapseAllContextMenuCommand(object sender, EventArgs e)
        {
            var command = sender as MenuCommand;
            command.Visible = true;
            var root = this.CurrentVisualLALDocData.RootElement as LALDominio;
            command.Enabled = (root?.Simbolos.Count > 0);
        }

        // WHAT TO DO
        private void OnMenuCollapseAllContextMenuCommand(object sender, EventArgs e)
        {
            var command = sender as MenuCommand;
            var store = this.CurrentDocData.Store;
            var simbolos = store.ElementDirectory.FindElements<Simbolo>();
            
            using (var transaction = store.TransactionManager.BeginTransaction("RecolherTudo"))
            {
                foreach (var simbolo in simbolos)
                {
                    var symbolShape = PresentationViewsSubject.GetPresentation(simbolo)
                        .FirstOrDefault() as SimboloCompartment;

                    symbolShape.IsExpanded = false;
                }
                transaction.Commit(); // Don't forget this!  
            }
        }
        #endregion

        #region ExpandAll
        private void OnStatusExpandAllContextMenuCommand(object sender, EventArgs e)
        {
            var command = sender as MenuCommand;
            command.Visible = true;
            var root = this.CurrentVisualLALDocData.RootElement as LALDominio;
            command.Enabled = (root?.Simbolos.Count > 0);
        }

        private void OnMenuExpandAllContextMenuCommand(object sender, EventArgs e)
        {
            var command = sender as MenuCommand;
            var store = this.CurrentDocData.Store;
            var symbols = store.ElementDirectory.FindElements<Simbolo>();

            using (var transaction = store.TransactionManager.BeginTransaction("ExpandirTudo"))
            {
                foreach (var symbol in symbols)
                {
                    var symbolShape =
                        PresentationViewsSubject.GetPresentation(symbol)
                        .FirstOrDefault() as SimboloCompartment;

                    symbolShape.IsExpanded = true;
                }
                transaction.Commit(); // Don't forget this!  
            }
        }
        #endregion

        #region AlignSymbols
        private void OnStatusAlignSymbolsContextMenuCommand(object sender, EventArgs e)
        {
            var command = sender as MenuCommand;
            command.Visible = true;
            var root = this.CurrentVisualLALDocData.RootElement as LALDominio;
            command.Enabled = (root?.Simbolos.Count > 0);
        }

        private void OnMenuAlignSymbolsContextMenuCommand(object sender, EventArgs e)
        {
            var command = sender as MenuCommand;
            var store = this.CurrentDocData.Store;

            using (var transaction = store.TransactionManager.BeginTransaction("AlinharSimbolos"))
            {
                var compartments = store.ElementDirectory.FindElements<SimboloCompartment>();
                try
                {
                    this.CurrentVisualLALDocView.CurrentDiagram.AutoLayoutShapeElements(compartments);
                    transaction.Commit(); // Don't forget this!  
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    System.Windows.Forms
                        .MessageBox.Show("Não foi possível alinhar os Símbolos. Desculpe por isso :("
                        , "FALHA AO ALINHAR"
                        , System.Windows.Forms.MessageBoxButtons.OK
                        , System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region FitToContent
        private void OnStatusFitSymbolsToContentContextMenuCommand(object sender, EventArgs e)
        {
            var command = sender as MenuCommand;
            var root = this.CurrentVisualLALDocData.RootElement as LALDominio;
            command.Visible = command.Enabled = (root?.Simbolos.Count > 0);
        }

        private void OnMenuFitSymbolsToContentContextMenuCommand(object sender, EventArgs e)
        {
            var command = sender as MenuCommand;
            var store = this.CurrentDocData.Store;
            var simbolos = store.ElementDirectory.FindElements<Simbolo>();
            if (simbolos.Count == 0)
                return;

            using (var transaction = store.TransactionManager.BeginTransaction("AjustarAoConteudo"))
            {
                try
                {
                    foreach (var simbolo in simbolos)
                        CompartmentHelper.AjustarAoConteudo(simbolo);

                    transaction.Commit(); // Don't forget this!  
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    System.Windows.Forms
                        .MessageBox.Show("Não foi possível ajustar o tamanho dos Símbolos. Desculpe por isso :("
                        , "FALHA AO AJUSTAR TAMANHO"
                        , System.Windows.Forms.MessageBoxButtons.OK
                        , System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region FitToDefault
        private void OnStatusFitSymbolsToDefaultContextMenuCommand(object sender, EventArgs e)
        {
            var command = sender as MenuCommand;
            var root = this.CurrentVisualLALDocData.RootElement as LALDominio;
            command.Visible = command.Enabled = (root?.Simbolos.Count > 0);
        }

        private void OnMenuFitSymbolsToDefaultContextMenuCommand(object sender, EventArgs e)
        {
            var command = sender as MenuCommand;
            var store = this.CurrentDocData.Store;
            var simbolos = store.ElementDirectory.FindElements<Simbolo>();
            if (simbolos.Count == 0)
                return;

            using (var transaction = store.TransactionManager.BeginTransaction("AjustarAoPadrao"))
            {
                try
                {
                    foreach (var simbolo in simbolos)
                        CompartmentHelper.AjustarAoPadrao(simbolo);

                    transaction.Commit(); // Don't forget this!  
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    System.Windows.Forms
                        .MessageBox.Show("Não foi possível ajustar o tamanho dos Símbolos. Desculpe por isso :("
                        , "FALHA AO AJUSTAR TAMANHO"
                        , System.Windows.Forms.MessageBoxButtons.OK
                        , System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        /*
        this.CurrentSelection. The shape that the user right-clicked is always included in this list. If the user clicks on a blank part of the diagram, the Diagram is the only member of the list.
        this.IsDiagramSelected() - true if the user clicked a blank part of the diagram.
        this.IsCurrentDiagramEmpty()
        this.IsSingleSelection() - the user did not select multiple objects
        this.SingleSelection - the shape or diagram that the user right-clicked
        shape.ModelElement as MyLanguageElement - the model element represented by a shape.
        As a general guideline, make the Visible property depend on what is selected, and make the Enabled property depend on the state of the selected elements.
        An OnStatus method should not change the state of the Store.
        */
    }
}

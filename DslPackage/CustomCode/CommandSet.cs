using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Shell;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using Microsoft.VisualStudio.Modeling.Diagrams;

namespace Maxsys.VisualLAL
{
    internal partial class VisualLALCommandSet
    {
        private Guid guidDiagramToolsMenuCmdSet = new Guid("9BE22312-4F7D-48BB-A5CB-2F0FA41597BB");
        private const int grpidDiagramToolsMenuGroup = 0x01001;
        private const int cmdidCollapseAllContextMenuCommand = 1;
        private const int cmdidExpandAllContextMenuCommand = 2;
        private const int cmdidAlignSymbolsContextMenuCommand = 3;
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
            // Add more commands here.  
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

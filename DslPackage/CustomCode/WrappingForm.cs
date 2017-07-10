using Maxsys.VisualLAL.CustomCode.Utils;
using Microsoft.VisualStudio.Modeling.Diagrams;
using Microsoft.VisualStudio.Modeling.Validation;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Maxsys.VisualLAL
{
    public partial class WrappingForm : UserControl
    {
        private VisualLALDocView docView;
        private LALDominio modelRoot;

        public WrappingForm()
        {
            InitializeComponent();
        }

        internal WrappingForm(VisualLALDocView docView, Control content)
            : this()
        {
            // Insert the DSL diagram into the Panel we've provided for it:
            diagramPanel.Controls.Add(content);
            
            // Allows access to DSL from the form:
            this.docView = docView;
        }
        
        private void btnValidate_Click(object sender, EventArgs e)
        {
            ExecuteModelValidation();
        }

        

        /// <summary>
        /// Callback on Store Event when items are added to model.
        /// </summary>
        /// <param name="c"></param>
        internal void Add(Simbolo e) { UpdatePartsList(); }
        
        /// <summary>
        /// Callback on Store Event items are removed from model.
        /// </summary>
        /// <param name="c"></param>
        internal void Remove(Simbolo e) { UpdatePartsList(); }

        /// <summary>
        /// Callback on Store Event items are property changed from model.
        /// </summary>
        /// <param name="c"></param>
        internal void PropertyUpdate(Simbolo e) { UpdatePartsList(); }

        /// <summary>
        /// Callback on Store Event when items are added to model.
        /// </summary>
        /// <param name="c"></param>
        internal void Add(Sinonimo e) { UpdatePartsList(); }

        /// <summary>
        /// Callback on Store Event items are removed from model.
        /// </summary>
        /// <param name="c"></param>
        internal void Remove(Sinonimo e) { UpdatePartsList(); }

        /// <summary>
        /// Callback on Store Event items are property changed from model.
        /// </summary>
        /// <param name="c"></param>
        internal void PropertyUpdate(Sinonimo e) { UpdatePartsList(); }



        /// <summary>
        /// Initialize the parts list when the model has loaded from file.
        /// </summary>
        internal void SetUpFormFromModel()
        {
            modelRoot = this.docView.CurrentDiagram.ModelElement as LALDominio;
            UpdatePartsList();
        }

        private void UpdatePartsList()
        {
            symbolsListBox.Items.Clear();
            foreach (var symbol in modelRoot.Simbolos)
                symbolsListBox.Items.Add(symbol);
        }

        private void symbolsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // A ideia inicial, é fazer com que o símbolo clicado neste listBox, 
            // seja centralizado na tela, facilitando a navegação do usuário.


            //* STARTING POINT:
            var listBox = sender as ListBox;
            if (listBox.SelectedIndex == -1)
                return; 
            var symbol = listBox.SelectedItem as Simbolo;
            var compartment = PresentationViewsSubject.GetPresentation(symbol)
                .FirstOrDefault() as SimboloCompartment;
            var diagram = docView.CurrentDiagram;
            

            var diagramItem = new DiagramItem(compartment);
            diagram.ActiveDiagramView.DiagramClientView.Selection.Set(diagramItem);
            diagram.ActiveDiagramView.DiagramClientView.Selection.FocusedItem = diagramItem;

            //*/

            /*
                Questões em forums
                https://stackoverflow.com/questions/34453796/how-do-i-get-the-starting-location-of-the-client-area-in-a-form-relative-to-the
                https://stackoverflow.com/questions/4998076/getting-the-location-of-a-control-relative-to-the-entire-screen

                Minhas questões
                https://pt.stackoverflow.com/questions/217431/dsl-tools-centralizar-um-shape-no-diagrama
                https://stackoverflow.com/questions/44876242/center-a-dsl-shape-on-diagram-screen
                https://social.msdn.microsoft.com/Forums/en-US/467401f6-3663-4e80-b532-fef04ba98b80/center-a-shape-on-diagram-screen?forum=dslvsarchx
                https://social.msdn.microsoft.com/Forums/vstudio/en-US/c587187f-42f0-4531-80d0-f2f5262fbcb0/dsl-tools-center-a-shape-on-diagram-screen?forum=vsx
            */

    }

        private void symbolsListBox_Leave(object sender, EventArgs e)
        {
            var listBox = sender as ListBox;
            listBox.ClearSelected();
        }

        private void btnExportHTML_Click(object sender, EventArgs e)
        {
            var isValid = ExecuteModelValidation();
            
            if(isValid)
            {
                try
                {
                    HTMLHelper.ExportarHTMLVisualLAL(modelRoot);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(this
                    , $"Invalid Model. The HTML cannot be exported:\r\n{ex.Message}"
                    , "EXPORT HTML HAS FAILED."
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                MessageBox.Show(this
                    , "HTML successfully exported."
                    , "EXPORT HTML"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(this
                    , "Invalid Model. The HTML cannot be exported."
                    , "EXPORT HTML HAS FAILED."
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ExecuteModelValidation()
        {
            // Call the validation controller that is attached to the document, 
            // so that any errors appear in the errors window.
            // See https://docs.microsoft.com/en-us/visualstudio/modeling/validation-in-a-domain-specific-language
            var docData = docView.DocData as VisualLALDocData;
            var controller = docData.ValidationController;
            var result = controller.Validate(docData.Store, ValidationCategories.Menu);
            return result;
        }
    }
}

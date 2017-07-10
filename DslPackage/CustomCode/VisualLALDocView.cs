using Maxsys.VisualLAL.CustomCode;
using Microsoft.VisualStudio.Modeling;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Maxsys.VisualLAL
{
    partial class VisualLALDocView
    {
        /// <summary>
        /// Gets the window containing the DSL.
        /// Normally this is just the VS window, but we place our form inside it.
        /// </summary>
        private WrappingForm container;
        public override IWin32Window Window
        {
            get
            {
                if (container == null)
                {
                    // Put our own form inside the DSL window:  
                    container = new WrappingForm(this, (Control)base.Window);
                }
                return container;
            }
        }


        /// <summary> Register store event listeners.  
        /// This method is called when the model and diagram    
        /// have completed loading.   
        /// </summary>  
        protected override bool LoadView()
        {
            var result = base.LoadView();

            #region Store event handler registration
            var store = this.DocData.Store;
            LELMaps.Instance.SetStore(store);

            // Store events are added to the various properties of the EMD:
            var emd = store.EventManagerDirectory;

            // Store events are registered per domain class, not per instance. After a listener is 
            // registered with a class, it is called for every change to any instance of the class:

            var simboloClassInfo = store.DomainDataDirectory.FindDomainClass(typeof(Simbolo));
            var sinonimoClassInfo = store.DomainDataDirectory.FindDomainClass(typeof(Sinonimo));

            emd.ElementAdded.Add(simboloClassInfo, new EventHandler<ElementAddedEventArgs>(AddSymbol));
            emd.ElementDeleted.Add(simboloClassInfo, new EventHandler<ElementDeletedEventArgs>(RemoveSymbol));
            emd.ElementPropertyChanged.Add(simboloClassInfo, new EventHandler<ElementPropertyChangedEventArgs>(UpdateSymbol));

            emd.ElementAdded.Add(sinonimoClassInfo, new EventHandler<ElementAddedEventArgs>(AddSynonym));
            emd.ElementDeleted.Add(sinonimoClassInfo, new EventHandler<ElementDeletedEventArgs>(RemoveSynonym));
            emd.ElementPropertyChanged.Add(sinonimoClassInfo, new EventHandler<ElementPropertyChangedEventArgs>(UpdateSynonym));

            // Do the initial parts list:
            container.SetUpFormFromModel();

            #endregion Store event handler registration

            return result;
        }

        ///<summary> 
        /// Listener method called on creation of each instance of the Symbol.
        /// Called once per instance that was added.
        /// This method was registered in LoadView().
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddSymbol(object sender, ElementAddedEventArgs e)
        {
            container.Add(e.ModelElement as Simbolo);
        }

        /// <summary>
        /// Listener method called after deletion of each instance of the Symbol class or its subclasses.
        /// Called once per instance that was deleted.
        /// This method was registered in LoadView().
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveSymbol(object sender, ElementDeletedEventArgs e)
        {
            container.Remove(e.ModelElement as Simbolo);
        }

        /// <summary>
        /// Listener method called after property changed of each instance of the Symbol class or its subclasses.
        /// Called once per instance that was updated.
        /// This method was registered in LoadView().
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateSymbol(object sender, ElementPropertyChangedEventArgs e)
        {
            container.PropertyUpdate(e.ModelElement as Simbolo);
        }


        ///<summary> 
        /// Listener method called on creation of each instance of the Synonym.
        /// Called once per instance that was added.
        /// This method was registered in LoadView().
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddSynonym(object sender, ElementAddedEventArgs e)
        {
            container.Add(e.ModelElement as Sinonimo);
        }

        /// <summary>
        /// Listener method called after deletion of each instance of the Synonym class or its subclasses.
        /// Called once per instance that was deleted.
        /// This method was registered in LoadView().
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveSynonym(object sender, ElementDeletedEventArgs e)
        {
            container.Remove(e.ModelElement as Sinonimo);
        }

        /// <summary>
        /// Listener method called after property changed of each instance of the Synonym class or its subclasses.
        /// Called once per instance that was updated.
        /// This method was registered in LoadView().
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateSynonym(object sender, ElementPropertyChangedEventArgs e)
        {
            container.PropertyUpdate(e.ModelElement as Sinonimo);
        }
    }
}
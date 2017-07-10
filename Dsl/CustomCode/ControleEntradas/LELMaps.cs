using Maxsys.VisualLAL.CustomCode.Maps;
using Microsoft.VisualStudio.Modeling;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxsys.VisualLAL.CustomCode
{
    /// <summary> Contains EntryMaps and LinkMaps.<para />
    /// Before use, is necessary to set Store <code>LELMaps.SetStore(store)</code>
    /// </summary>
    public class LELMaps
    {
        #region Properties
        public MapeamentoReferencias LinkMaps { get; }
        public EntryMapSet Entries { get; }

        private Store Store { get; set; }

        public void SetStore(Store store)
        {
            Store = store;
            LinkMaps.SetStore(store);
        }
        #endregion


        #region Singleton
        private static LELMaps _maps;
        public static LELMaps Instance
        {
            get
            {
                if (_maps == null)
                {
                    _maps = new LELMaps();
                }

                return _maps;
            }
        }

        private LELMaps()
        {
            Entries = EntryMapSet.Instance;
            LinkMaps = MapeamentoReferencias.Instance;

            Entries.EntryMapAdded += EntryMapSet_Added;
            Entries.EntryMapUpdated += EntryMapSet_Updated;
            Entries.EntryMapRemoved += EntryMapSet_Removed;

            LinkMaps.LinkMapAdded += LinkMapSet_Added;
            LinkMaps.LinkMapRemoved += LinkMapSet_Removed;
        }
        #endregion


        #region Events

        #region EntryMap
        private void EntryMapSet_Added(object source, MapaDeEntradaEventArgs e)
        {
            Debug.WriteLine($"WordSet_Added = [{e.MapaDeEntrada.EntradaUnica}]");
            LinkMaps.AnalisaEAdicionaMapaDeReferenciaParaNovaEntrada(e.MapaDeEntrada);
        }

        private void EntryMapSet_Updated(object source, MapaDeEntradaAtualizadoEventArgs e)
        {
            Debug.WriteLine($"WordMap_Updated = O[{e.MapaDeEntradaAntigo.EntradaUnica}] N[{e.MapaDeEntradaNovo.EntradaUnica}]");
            LinkMaps.AtualizaMapaDeReferenciaAposAlteracaoDeEntrada(e.MapaDeEntradaAntigo, e.MapaDeEntradaNovo);
        }

        private void EntryMapSet_Removed(object source, MapaDeEntradaEventArgs e)
        {
            Debug.WriteLine($"WordMap_Removed = [{e.MapaDeEntrada.EntradaUnica}]");
            LinkMaps.RemoveReferenciasDeEntrada(e.MapaDeEntrada);
        }
        #endregion
        #region LinkMap
        private void LinkMapSet_Added(object source, LinkMapEventArgs e)
        {
            var sourceSimbolo = Store.ElementDirectory.FindElement(e.SourceSimboloId) as Simbolo;
            var targetSimbolo = Store.ElementDirectory.FindElement(e.TargetSimboloId) as Simbolo;

            Debug.WriteLine($"LinkSet_Added = [{sourceSimbolo.Nome}] -> [{targetSimbolo.Nome}]");

            var sourceIsNotTarget = !sourceSimbolo.Id.Equals(targetSimbolo.Id);
            var hasLinkMapBetweenSourceAndTarget = LinkMaps.HasLinkMap(sourceSimbolo, targetSimbolo);
            var islinkedSourceToTarget = SimboloReferences.GetLinks(sourceSimbolo, targetSimbolo).Any();
            var islinkedTargetToSource = SimboloReferences.GetLinks(targetSimbolo, sourceSimbolo).Any();
            var isNotAlreadyLinked = !(islinkedSourceToTarget || islinkedTargetToSource);

            if (sourceIsNotTarget && hasLinkMapBetweenSourceAndTarget && isNotAlreadyLinked)
            {
                using (var transaction = Store.TransactionManager.BeginTransaction("LinkMapSet_Added"))
                {
                    var linked = SimboloReferencesBuilder.Connect(sourceSimbolo, targetSimbolo) as SimboloReferences;
                    transaction.Commit();
                }
            }
        }

        private void LinkMapSet_Removed(object source, LinkMapEventArgs e)
        {
            Debug.Write($"LinkSet_Removed");
            var sourceSimbolo = Store.ElementDirectory.FindElement(e.SourceSimboloId) as Simbolo;
            var targetSimbolo = Store.ElementDirectory.FindElement(e.TargetSimboloId) as Simbolo;

            // Whether any of two simbolos is null, means that the simbolo has been deleted
            // and hyperlink is deleted too.
            if (sourceSimbolo == null || targetSimbolo == null)
                return;

            Debug.Write($" = [{sourceSimbolo.Nome}] -> [{targetSimbolo.Nome}]");

            var stillHasLinkMap = LinkMaps.HasLinkMap(sourceSimbolo, targetSimbolo);
            
            // If still has link maps between this two simbolos, 
            // means the Hyperlink must not be deleted.
            if (stillHasLinkMap)
            {
                Debug.WriteLine($" {{Ainda tem Link}}");
                return;
            }

            var sourceToTargetLinks = SimboloReferences.GetLinks(sourceSimbolo, targetSimbolo);
            var targetToSourceLinks = SimboloReferences.GetLinks(targetSimbolo, sourceSimbolo);

            var countLinks = sourceToTargetLinks.Count + targetToSourceLinks.Count;

            Debug.WriteLine($" {{SEM mais Links}}. Connectores removidos={countLinks}");

            using (var transaction
                = Store.TransactionManager.BeginTransaction("LinkMapSet_Removed"))
            {
                foreach (var link in sourceToTargetLinks)
                    link.Delete();
                foreach (var link in targetToSourceLinks)
                    link.Delete();

                //Debug.WriteLine($"LinkMapSet_Removed=[{countLinks}]");
                transaction.Commit();
            }
        }


        #endregion
        
        #endregion
    }
}

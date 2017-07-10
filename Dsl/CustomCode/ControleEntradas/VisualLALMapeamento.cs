using Maxsys.VisualLAL.CustomCode.Maps;
using Microsoft.VisualStudio.Modeling;
using System.Collections.Generic;
using System.Linq;

namespace Maxsys.VisualLAL.CustomCode
{
    /// <summary> Contains EntryMaps and LinkMaps.<para />
    /// Before use, is necessary to set Store <code>LELMaps.SetStore(store)</code>
    /// </summary>
    public class VisualLALMapeamento
    {
        #region Properties
        public MapeamentoReferencias MapaReferencias { get; }
        public MapeamentoEntradas MapaEntradas { get; }
        public HashSet<Entrada> Entradas { get; }

        private Store Store { get; set; } = null;

        public void SetStore(Store store)
        {
            if (Store == null)
            {
                Store = store;
                /*debug*/ System.Diagnostics.Debug.WriteLine($"VisualLALMapeamento.Store = [{Store.Id}]");
                MapaReferencias.SetStore(store);
            }
            
        }
        #endregion


        #region Singleton
        private static VisualLALMapeamento _maps;
        public static VisualLALMapeamento Instance
        {
            get
            {
                if (_maps == null)
                {
                    _maps = new VisualLALMapeamento();
                }

                return _maps;
            }
        }

        private VisualLALMapeamento()
        {
            MapaEntradas = MapeamentoEntradas.Instance;
            MapaReferencias = MapeamentoReferencias.Instance;
            Entradas = new HashSet<Entrada>();

            MapaEntradas.EntryMapAdded += EntryMapSet_Added;
            MapaEntradas.EntryMapUpdated += EntryMapSet_Updated;
            MapaEntradas.EntryMapRemoved += EntryMapSet_Removed;

            MapaReferencias.LinkMapAdded += LinkMapSet_Added;
            MapaReferencias.LinkMapRemoved += LinkMapSet_Removed;
        }
        #endregion


        #region Events

        #region EntryMap
        private void EntryMapSet_Added(object source, MapaDeEntradaEventArgs e)
        {
            /*debug*/System.Diagnostics.Debug.WriteLine($"WordSet_Added = [{e.MapaDeEntrada.EntradaUnica}]");
            MapaReferencias.AnalisaEAdicionaMapaDeReferenciaParaNovaEntrada(e.MapaDeEntrada);
        }

        private void EntryMapSet_Updated(object source, MapaDeEntradaAtualizadoEventArgs e)
        {
            /*debug*/System.Diagnostics.Debug.WriteLine($"WordMap_Updated = O[{e.MapaDeEntradaAntigo.EntradaUnica}] N[{e.MapaDeEntradaNovo.EntradaUnica}]");
            MapaReferencias.AtualizaMapaDeReferenciaAposAlteracaoDeEntrada(e.MapaDeEntradaAntigo, e.MapaDeEntradaNovo);
        }

        private void EntryMapSet_Removed(object source, MapaDeEntradaEventArgs e)
        {
            /*debug*/System.Diagnostics.Debug.WriteLine($"WordMap_Removed = [{e.MapaDeEntrada.EntradaUnica}]");
            MapaReferencias.RemoveReferenciasDeEntrada(e.MapaDeEntrada);
        }
        #endregion
        #region LinkMap
        private void LinkMapSet_Added(object source, LinkMapEventArgs e)
        {
            var sourceSimbolo = Store.ElementDirectory.FindElement(e.SourceSimboloId) as Simbolo;
            var targetSimbolo = Store.ElementDirectory.FindElement(e.TargetSimboloId) as Simbolo;

            /*debug*/System.Diagnostics.Debug.WriteLine($"LinkSet_Added = [{sourceSimbolo.Nome}] -> [{targetSimbolo.Nome}]");
            var sourceIsNotTarget = !sourceSimbolo.Id.Equals(targetSimbolo.Id);
            var hasLinkMapBetweenSourceAndTarget = MapaReferencias.HasLinkMap(sourceSimbolo, targetSimbolo);
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
            /*debug*/System.Diagnostics.Debug.Write($"LinkSet_Removed");
            var sourceSimbolo = Store.ElementDirectory.FindElement(e.SourceSimboloId) as Simbolo;
            var targetSimbolo = Store.ElementDirectory.FindElement(e.TargetSimboloId) as Simbolo;

            // Whether any of two simbolos is null, means that the simbolo has been deleted
            // and hyperlink is deleted too.
            if (sourceSimbolo == null || targetSimbolo == null)
                return;

            /*debug*/System.Diagnostics.Debug.Write($" = [{sourceSimbolo.Nome}] -> [{targetSimbolo.Nome}]");

            var stillHasLinkMap = MapaReferencias.HasLinkMap(sourceSimbolo, targetSimbolo);
            
            // If still has link maps between this two simbolos, 
            // means the Hyperlink must not be deleted.
            if (stillHasLinkMap)
            {
                /*debug*/System.Diagnostics.Debug.WriteLine($" {{Ainda tem Link}}");
                return;
            }

            var sourceToTargetLinks = SimboloReferences.GetLinks(sourceSimbolo, targetSimbolo);
            var targetToSourceLinks = SimboloReferences.GetLinks(targetSimbolo, sourceSimbolo);

            var countLinks = sourceToTargetLinks.Count + targetToSourceLinks.Count;

            /*debug*/System.Diagnostics.Debug.WriteLine($" {{SEM mais Links}}. Connectores removidos={countLinks}");

            using (var transaction
                = Store.TransactionManager.BeginTransaction("LinkMapSet_Removed"))
            {
                foreach (var link in sourceToTargetLinks)
                    link.Delete();
                foreach (var link in targetToSourceLinks)
                    link.Delete();

                /*debug*/System.Diagnostics.Debug.WriteLine($"LinkMapSet_Removed=[{countLinks}]");
                transaction.Commit();
            }
        }


        #endregion
        
        #endregion
    }
}

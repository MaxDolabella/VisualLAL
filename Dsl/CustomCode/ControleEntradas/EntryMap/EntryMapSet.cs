using Microsoft.VisualStudio.Modeling;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Maxsys.VisualLAL.CustomCode.Maps
{
    /// <summary>
    /// Represents a set of WordMap thats contains all uniques entries of LEL
    /// </summary>
    [Serializable]
    public class EntryMapSet : SortedSet<MapaDeEntrada>, IEnumerable<MapaDeEntrada>
    {
        #region Singleton
        private static EntryMapSet _instance;
        public static EntryMapSet Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EntryMapSet();
                }

                return _instance;
            }
        }

        private EntryMapSet()
        { }
        #endregion


        #region Events Declarations
        public delegate void EntryMapAddedEventHandler(object source, MapaDeEntradaEventArgs e);
        public delegate void EntryMapUpdatedEventHandler(object source, MapaDeEntradaAtualizadoEventArgs e);
        public delegate void EntryMapRemovedEventHandler(object source, MapaDeEntradaEventArgs e);

        public event EntryMapAddedEventHandler EntryMapAdded;
        public event EntryMapUpdatedEventHandler EntryMapUpdated;
        public event EntryMapRemovedEventHandler EntryMapRemoved;


        private void OnEntryMapAdded(MapaDeEntrada mapaDeEntrada)
        {
            EntryMapAdded?.Invoke(this, new MapaDeEntradaEventArgs(mapaDeEntrada));
        }
        private void OnEntryMapUpdated(MapaDeEntrada mapaDeEntradaAntigo, MapaDeEntrada mapaDeEntradaNovo)
        {
            EntryMapUpdated?.Invoke(this, new MapaDeEntradaAtualizadoEventArgs(mapaDeEntradaAntigo, mapaDeEntradaNovo));
        }
        private void OnEntryMapRemoved(MapaDeEntrada mapaDeEntrada)
        {
            EntryMapRemoved?.Invoke(this, new MapaDeEntradaEventArgs(mapaDeEntrada));
        }
        #endregion


        #region Indexes
        public MapaDeEntrada this[string entradaUnica]
        {
            get
            {
                return this
                    .Where(x => x.EntradaUnica == entradaUnica)
                    .SingleOrDefault();
            }
        }
        public MapaDeEntrada this[Guid entradaId]
        {
            get
            {
                return this
                    .Where(x => x.EntradaId == entradaId)
                    .SingleOrDefault();
            }
        }
        #endregion


        #region Methods
        
        public bool Add(Simbolo simbolo)
        {
            var novaEntrada = new MapaDeEntrada(simbolo);

            var adicionado = Add(novaEntrada);
            if (adicionado)
                OnEntryMapAdded(novaEntrada);

            return adicionado;
        }
        public bool Add(Sinonimo sinonimo)
        {
            var novaEntrada = new MapaDeEntrada(sinonimo);

            var adicionado = Add(novaEntrada);
            if (adicionado)
                OnEntryMapAdded(novaEntrada);

            return adicionado;
        }
        private new bool Add(MapaDeEntrada item)
        {
            var adicionado = false;
            if (!Contains(item))
                adicionado = base.Add(item);
            return adicionado;
        }
        public void UpdateEntry(Entrada entrada)
        {
            if (!Contains(entrada.Nome))
            {
                var mapaAntigo = this[entrada.Id];
                var mapaNovo = new MapaDeEntrada(entrada);

                Remove(mapaAntigo);

                var adicionado = Add(mapaNovo);
                if (adicionado)
                    OnEntryMapUpdated(mapaAntigo, mapaNovo);
            }
            else
            {
                //throw new ArgumentException($"mapaEntradaset.UpdateEntry: There is no WordMap with value {{{oldEntry}}}");
            }
        }
        

        public bool Contains(string uniqueWord)
        {
            return this.Any(m => m.EntradaUnica.ContainsExtactExpression(uniqueWord));
        }
        public bool Contains(Guid elementId)
        {
            return this.Any(m => m.EntradaId == elementId);
        }


        private void Remove(Guid entradaId)
        {
            if (Contains(entradaId))
            {
                var mapa = this[entradaId];
                var result = Remove(mapa);
                if (result)
                    OnEntryMapRemoved(mapa);
            }
            else
            {
                throw new ArgumentException($"mapaEntradaset.Remove: There is no WordMap with elementId {{{entradaId}}}");
            }
        }
        public void Remove(Simbolo simbolo)
        {
            foreach (var s in simbolo.Sinonimos)
                Remove(s.Id);
            Remove(simbolo.Id);
        }
        public void Remove(Sinonimo sinonimo)
        {
            Remove(sinonimo.Id);
        }
        
        public new IEnumerator<MapaDeEntrada> GetEnumerator()
        {
            return base.GetEnumerator();
        }
        #endregion

    }

    
}

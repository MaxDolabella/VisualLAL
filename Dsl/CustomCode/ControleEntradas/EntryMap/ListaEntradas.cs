using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Maxsys.VisualLAL.CustomCode.Maps
{
    /// <summary>
    /// Represents a set of WordMap thats contains all uniques entries of LEL
    /// </summary>
    public class MapeamentoEntradasLISTA : IEnumerable<MapaDeEntrada>
    {
        private SortedSet<MapaDeEntrada> _lista;

        #region Singleton
        private static MapeamentoEntradasLISTA _instance;
        public static MapeamentoEntradasLISTA Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MapeamentoEntradasLISTA();
                }

                return _instance;
            }
        }

        private MapeamentoEntradasLISTA()
        {
            _lista = new SortedSet<MapaDeEntrada>();
        }
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
                return _lista
                    .Where(x => x.EntradaUnica.Equals(entradaUnica))
                    .SingleOrDefault();
            }
        }
        public MapaDeEntrada this[Guid entradaId]
        {
            get
            {
                return _lista
                    .Where(x => x.EntradaId.Equals(entradaId))
                    .SingleOrDefault();
            }
        }
        #endregion


        #region Methods

        #region Métodos Privados
        private bool Add(MapaDeEntrada item)
        {
            var adicionado = false;
            if (!_lista.Contains(item))
                adicionado = _lista.Add(item);
            return adicionado;
        }
        private void Remove(Guid entradaId)
        {
            var mapa = this[entradaId];
            var result = _lista.Remove(mapa);
            if (result)
                OnEntryMapRemoved(mapa);
        }

        public IEnumerator<MapaDeEntrada> GetEnumerator()
        {
            return ((IEnumerable<MapaDeEntrada>)_lista).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<MapaDeEntrada>)_lista).GetEnumerator();
        }

        public void ApagarTudo()
        {
            _lista.Clear();
        }
        #endregion
        #region Métodos Públicos
        public bool Adicionar(Simbolo simbolo)
        {
            var novaEntrada = new MapaDeEntrada(simbolo);

            var adicionado = Add(novaEntrada);
            if (adicionado)
                OnEntryMapAdded(novaEntrada);

            return adicionado;
        }
        public bool Adicionar(Sinonimo sinonimo)
        {
            var novaEntrada = new MapaDeEntrada(sinonimo);

            var adicionado = Add(novaEntrada);
            if (adicionado)
                OnEntryMapAdded(novaEntrada);

            return adicionado;
        }
        
        public void AtualizarEntrada(Entrada entrada)
        {
            var mapaAntigo = this[entrada.Id];
            var novaEntrada = new MapaDeEntrada(entrada);

            _lista.Remove(mapaAntigo);

            var adicionado = Add(novaEntrada);
            if (adicionado)
                OnEntryMapUpdated(mapaAntigo, novaEntrada);
        }

        public bool Contem(string uniqueWord)
        {
            return _lista.Any(m => m.EntradaUnica.ContainsExtactExpression(uniqueWord));
        }
        public bool Contem(Guid elementId)
        {
            return _lista.Any(m => m.EntradaId.Equals(elementId));
        }
        
        public void Remover(Simbolo simbolo)
        {
            foreach (var s in simbolo.Sinonimos)
                Remove(s.Id);
            Remove(simbolo.Id);
        }
        public void Remover(Sinonimo sinonimo)
        {
            Remove(sinonimo.Id);
        }
        #endregion

        #endregion

    }
}

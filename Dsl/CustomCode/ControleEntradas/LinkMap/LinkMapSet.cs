using Microsoft.VisualStudio.Modeling;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Maxsys.VisualLAL.CustomCode.Maps
{
    /// <summary>
    /// Represents a set of LinkMapSet thats contains all linked simbolos of LEL.
    /// </summary>
    public class MapeamentoReferencias : IEnumerable<MapaDeReferencia>
    {
        private SortedSet<MapaDeReferencia> _lista;
        private Store _store;

        #region Singleton
        private static MapeamentoReferencias _instance;
        public static MapeamentoReferencias Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MapeamentoReferencias();
                }

                return _instance;
            }
        }

        private MapeamentoReferencias()
        {
            _lista = new SortedSet<MapaDeReferencia>();
        }
        #endregion


        #region Events Declarations
        public delegate void LinkMapAddedEventHandler(object source, LinkMapEventArgs e);
        public delegate void LinkMapRemovedEventHandler(object source, LinkMapEventArgs e);

        public event LinkMapAddedEventHandler LinkMapAdded;
        public event LinkMapRemovedEventHandler LinkMapRemoved;

        private void OnLinkMapAdded(Guid sourceSimboloId, Guid targetSimboloId)
        {
            LinkMapAdded?.Invoke(this, new LinkMapEventArgs(sourceSimboloId, targetSimboloId));
        }
        
        private void OnLinkMapRemoved(Guid sourceSimboloId, Guid targetSimboloId)
        {
            LinkMapRemoved?.Invoke(this, new LinkMapEventArgs(sourceSimboloId, targetSimboloId));
        }
        #endregion


        #region Indexes
        public MapaDeReferencia this[string entrada]
        {
            get
            {
                return _lista
                    .Where(x => x.EntradaReferenciada.Equals(entrada))
                    .SingleOrDefault();
            }
        }
        #endregion


        #region Methods

        #region Métodos Públicos
        public void SetStore(Store store)
        {
            _store = store;
            /*debug*/System.Diagnostics.Debug.WriteLine($"MapeamentoReferencias._store = [{_store.Id}]");
        }

        public bool HasLinkMap(Simbolo simbolo1, Simbolo simbolo2)
        {
            return this.Any
                (m =>
                (m.SimboloOrigemId.Equals(simbolo1.Id) && m.SimboloDestinoId.Equals(simbolo2.Id)) ||
                (m.SimboloOrigemId.Equals(simbolo2.Id) && m.SimboloDestinoId.Equals(simbolo1.Id))
                );

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<MapaDeReferencia>)_lista).GetEnumerator();
        }

        public IEnumerator<MapaDeReferencia> GetEnumerator()
        {
            return ((IEnumerable<MapaDeReferencia>)_lista).GetEnumerator();
        }

        public void ApagarTudo()
        {
            _lista.Clear();
        }
        #endregion
        #region Métodos Privados
        private bool Adiciona(MapaDeReferencia mapaDeReferencia)
        {
            var resultado = false;
            if (!Contem(mapaDeReferencia))
                resultado = _lista.Add(mapaDeReferencia);

            if (resultado)
                OnLinkMapAdded(mapaDeReferencia.SimboloOrigemId, mapaDeReferencia.SimboloDestinoId);

            return resultado;
        }

        private void Remove(MapaDeReferencia mapaDeReferencia)
        {
            var removido = _lista.Remove(mapaDeReferencia);
            if (removido)
            {
                OnLinkMapRemoved(mapaDeReferencia.SimboloOrigemId, mapaDeReferencia.SimboloDestinoId);
            }
        }
        private bool Contem(MapaDeReferencia mapaDeReferencia)
        {
            return _lista.Any(m => m.Equals(mapaDeReferencia));
        }

        private void AnalisaEAdicionaMapaDeReferencia(MapaDeEntrada mapaEntrada, SubEntrada subEntrada)
        {
            var textoContemAlgumaEntrada = subEntrada.Texto.ContainsExtactExpression(mapaEntrada.EntradaUnica);
            if (textoContemAlgumaEntrada)
            {
                var novoMapaDeReferencia = new MapaDeReferencia(mapaEntrada, subEntrada);

                if (!Contem(novoMapaDeReferencia))
                    Adiciona(novoMapaDeReferencia);
            }
        }

        #endregion
        #region Entradas
        /// <summary>
        /// Busca por novas referências entre <typeparamref name="Entrada"/>s
        /// </summary>
        /// <param name="mapaEntrada">Representa um <typeparamref name="MapaDeEntrada"/> para o qual se deseja buscar novas referências</param>
        public void AnalisaEAdicionaMapaDeReferenciaParaNovaEntrada(MapaDeEntrada mapaEntrada)
        {
            var subEntradas = _store.ElementDirectory.FindElements<SubEntrada>();
            
            /*debug*/System.Diagnostics.Debug.WriteLine($"AnalisaEAdicionaMapaDeReferenciaParaNovaEntrada mapa[{mapaEntrada.EntradaUnica}] _store[{_store.Id}] subEntradas[{subEntradas.Count()}]");
            foreach (var item in subEntradas)
                AnalisaEAdicionaMapaDeReferencia(mapaEntrada, item as SubEntrada);
        }

        /// <summary>
        /// Updates link maps from removing old links of <paramref name="oldEntry"/> 
        /// and adding new from <paramref name="newEntry"/>
        /// </summary>
        /// <param name="oldEntry">The old entry that needs to be removed</param>
        /// <param name="newEntry">The new entry that needs to be added</param>
        /// <param name="elementId">Represents the element (Simbolo or Sinonimo) owner of <paramref name="newEntry"/></param>

        public void AtualizaMapaDeReferenciaAposAlteracaoDeEntrada(MapaDeEntrada mapaAntigo, MapaDeEntrada mapaNovo)
        {
            /*debug*/System.Diagnostics.Debug.WriteLine($"Entrou em AtualizaMapaDeReferenciaAposAlteracaoDeEntrada o[{mapaAntigo.EntradaUnica}] n[{mapaNovo.EntradaUnica}]");
            RemoveReferenciasDeEntrada(mapaAntigo);
            AnalisaEAdicionaMapaDeReferenciaParaNovaEntrada(mapaNovo);
        }

        /// <summary>
        /// Removes all Link map that references the entry indicated
        /// </summary>
        /// <param name="entry"></param>
        public void RemoveReferenciasDeEntrada(MapaDeEntrada mapa)
        {
            var referencias = new List<MapaDeReferencia>
                (
                _lista.Where(mRef => mRef.EntradaReferenciada.Equals(mapa.EntradaUnica))
                );

            foreach (var referencia in referencias)
                Remove(referencia);
        }
        #endregion
        #region SubEntradas
        /// <summary>
        /// Check whether newly added nocao references some entry and adds it if necessary
        /// </summary>
        /// <param name="nocao">Is the newly added nocao.</param>
        public void AnalisaEAdicionaMapaDeReferenciaParaNovaSubEntrada(SubEntrada subEntrada)
        {
            foreach (var mapaEntrada in VisualLALMapeamento.Instance.MapaEntradas)
            {
                AnalisaEAdicionaMapaDeReferencia(mapaEntrada, subEntrada);
            }
        }

        /// <summary>
        /// Updates link maps from newly changed nocao.
        /// </summary>
        /// <param name="nocao">Is the newly changed nocao.</param>
        public void AtualizaMapaDeReferenciaAposAlteracaoDeSubEntrada(SubEntrada subEntrada)
        {
            RemoverReferenciasDeSubEntrada(subEntrada);
            AnalisaEAdicionaMapaDeReferenciaParaNovaSubEntrada(subEntrada);
        }

        /// <summary>
        /// Removes all Link map that references from nocao specified.
        /// </summary>
        /// <param name="nocao"></param>
        public void RemoverReferenciasDeSubEntrada(SubEntrada subEntrada)
        {
            var referencias = new List<MapaDeReferencia>
                (
                _lista.Where(mRef => mRef.SubEntradaOrigemId.Equals(subEntrada.Id))
                );

            foreach (var referencia in referencias)
                Remove(referencia);
        }

        


        #endregion

        #endregion
    }
}

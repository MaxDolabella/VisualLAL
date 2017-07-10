using System;

namespace Maxsys.VisualLAL.CustomCode.Maps
{
    /// <summary>
    /// Contém um mapa de referência entre <typeparamref name="Simbolo"/>s, através de uma entrada única.
    /// </summary>
    public class MapaDeReferencia : IComparable<MapaDeReferencia>
    {
        /// <summary>
        /// Construtor para <typeparamref name="MapaDeReferencia"/>.
        /// </summary>
        /// <param name="entradaReferenciada">Is the linked entry.</param>
        /// <param name="subEntradaOrigem">Is the source Element that references the entry.</param>
        /// <param name="source">Is the source Simbolo that references the entry.</param>
        /// <param name="simboloDestino">Is the target referencied Simbolo (entry owner).</param>
        public MapaDeReferencia(MapaDeEntrada mapaDeEntrada, SubEntrada subEntradaOrigem)
        {
            //SimboloOrigemId:
            if (subEntradaOrigem is Nocao)
                SimboloOrigemId = (subEntradaOrigem as Nocao).Simbolo.Id;
            else
                SimboloOrigemId = (subEntradaOrigem as Impacto).Simbolo.Id;

            //SimboloDestinoId:
            var entrada = subEntradaOrigem.Store.ElementDirectory.FindElement(mapaDeEntrada.EntradaId);
            if (entrada is Simbolo)
                SimboloDestinoId = entrada.Id;
            else
                SimboloDestinoId = (entrada as Sinonimo).Simbolo.Id;

            EntradaReferenciada = mapaDeEntrada.EntradaUnica;
            SubEntradaOrigemId = subEntradaOrigem.Id;
        }

        /// <summary>
        /// Represents a linked entry in LEL diagram. Can be a Simbolo name or any of his Sinonimos
        /// </summary>
        public string EntradaReferenciada { get; }
        
        /// <summary>
        /// Represents the source Element that references the entry.
        /// </summary>
        public Guid SubEntradaOrigemId { get; }
        
        /// <summary>
        /// Represents the source Simbolo that references the entry.
        /// </summary>
        public Guid SimboloOrigemId { get; }

        /// <summary>
        /// Represents the target Simbolo referencied (entry owner)..
        /// </summary>
        public Guid SimboloDestinoId { get; }

        public override string ToString()
        {
            return $"[{EntradaReferenciada}] {SimboloOrigemId} references {SimboloDestinoId}";
        }
        public override bool Equals(object obj)
        {
            var item = obj as MapaDeReferencia;
            if (item == null)
                return false;

            var linkedEntryEquality = this.EntradaReferenciada.Equals(item.EntradaReferenciada);
            var sourceElementEquality = this.SubEntradaOrigemId.Equals(item.SubEntradaOrigemId);
            var linkedSimbolosEquality = 
                this.SimboloOrigemId.Equals(item.SimboloOrigemId) && 
                this.SimboloDestinoId.Equals(item.SimboloDestinoId);

            return linkedEntryEquality && sourceElementEquality && linkedSimbolosEquality;
        }
        public override int GetHashCode()
        {
            return new { EntradaReferenciada, SubEntradaOrigemId, SimboloOrigemId, SimboloDestinoId }.GetHashCode();
        }
        public int CompareTo(MapaDeReferencia obj)
        {
            int result = this.EntradaReferenciada.CompareTo(obj.EntradaReferenciada);
            if (result == 0)
                result = this.SubEntradaOrigemId.CompareTo(obj.SubEntradaOrigemId);
            if (result == 0)
                result = this.SimboloOrigemId.CompareTo(obj.SimboloOrigemId);
            if (result == 0)
                result = this.SimboloDestinoId.CompareTo(obj.SimboloDestinoId);
            return result;
        }
    }
}

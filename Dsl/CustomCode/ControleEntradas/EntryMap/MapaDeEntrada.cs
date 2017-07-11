using System;

namespace Maxsys.VisualLAL.CustomCode.Maps
{
    /// <summary>
    /// Contém um mapa de cada entrada no VisualLAL.
    /// </summary>
    public class MapaDeEntrada : IComparable<MapaDeEntrada>
    {
        #region Constructors

        /// <summary>
        /// Construtor para um <typeparamref name="MapaDeEntrada"/> a partir de uma <typeparamref name="Entrada"/>.
        /// </summary>
        /// <param name="entrada">Representa uma <typeparamref name="Entrada"/> no LAL. Pode ser um <typeparamref name="Simbolo"/> ou <typeparamref name="Sinonimo"/>.</param>
        public MapaDeEntrada(Entrada entrada)
            : this(entrada.Nome, entrada.Id)
        { }

        /// <summary>
        /// Construtor para um <typeparamref name="MapaDeEntrada"/>.
        /// </summary>
        /// <param name="entradaUnica">É uma entrada única no LAL.</param>
        /// <param name="entradaId">É o id da <typeparamref name="Entrada"/> a qual a <paramref name="entradaUnica"/> pertence.</param>
        private MapaDeEntrada(string entradaUnica, Guid entradaId)
        {
            EntradaUnica = entradaUnica;
            EntradaId = entradaId;
        }
        #endregion


        #region Properties
        /// <summary>
        /// É uma entrada única no LAL. Pode ser um nome de <typeparamref name="Simbolo"/> ou <typeparamref name="Sinonimo"/>.
        /// </summary>
        public string EntradaUnica { get; }

        /// <summary>
        /// É o Id da <typeparamref name="Entrada"/> a qual a <paramref name="EntradaUnica"/> pertence.
        /// </summary>
        public Guid EntradaId { get; }
        #endregion


        #region Methods
        public override string ToString()
        {
            return $"[{EntradaUnica}] {EntradaId}";
        }
        public override bool Equals(object obj)
        {
            var item = obj as MapaDeEntrada;

            if (item == null)
                return false;

            return this.EntradaUnica.Equals(item.EntradaUnica);
        }
        public override int GetHashCode()
        {
            return new { EntradaUnica, EntradaId }.GetHashCode();
        }
        public int CompareTo(MapaDeEntrada obj)
        {
            return EntradaUnica.CompareTo(obj.EntradaUnica) * -1;
        }
        #endregion
    }
}

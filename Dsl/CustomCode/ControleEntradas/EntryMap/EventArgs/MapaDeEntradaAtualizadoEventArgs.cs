using System;

namespace Maxsys.VisualLAL.CustomCode.Maps
{
    public class MapaDeEntradaAtualizadoEventArgs : EventArgs
    {
        public MapaDeEntradaAtualizadoEventArgs(MapaDeEntrada mapaDeEntradaAntigo, MapaDeEntrada mapaDeEntradaNovo)
        {
            MapaDeEntradaAntigo = mapaDeEntradaAntigo;
            MapaDeEntradaNovo = mapaDeEntradaNovo;
        }
        public MapaDeEntrada MapaDeEntradaAntigo { get; }
        public MapaDeEntrada MapaDeEntradaNovo { get; }
    }
}

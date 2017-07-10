using System;

namespace Maxsys.VisualLAL.CustomCode.Maps
{
    public class MapaDeEntradaEventArgs : EventArgs
    {
        public MapaDeEntrada MapaDeEntrada { get; }

        public MapaDeEntradaEventArgs(MapaDeEntrada mapaDeEntrada)
        {
            MapaDeEntrada = mapaDeEntrada;
        }
    }
}

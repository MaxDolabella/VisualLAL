using System;

namespace Maxsys.VisualLAL.CustomCode.Maps
{
    public class LinkMapEventArgs : EventArgs
    {
        public Guid SourceSimboloId { get; }
        public Guid TargetSimboloId { get; }

        public LinkMapEventArgs(Guid sourceSimboloId, Guid targetSimboloId)
        {
            SourceSimboloId = sourceSimboloId;
            TargetSimboloId = targetSimboloId;
        }
    }
}
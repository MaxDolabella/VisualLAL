using System.Linq;

namespace Maxsys.VisualLAL
{
    partial class Simbolo
    {
        public override string ToString()
        {
            /*
            Símbolo Time:
                Nome = "Time"
                Sinônimos = "Equipe", "Clube"

            ToString() = "Time / Equipe / Clube"
            */
            var separador = " / ";
            var nome = this.Nome;
            var sinonimos = "";
            if (this.Sinonimos.Count > 0)
                sinonimos = separador + string.Join(separador, this.Sinonimos.Select(s => s.Nome));
            return $"{nome}{sinonimos}";
        }
    }
}

using Maxsys.VisualLAL.CustomCode.Interfaces.Specification;
using System.Linq;

namespace Maxsys.VisualLAL.CustomCode.PrincipioDaCircularidade.Specification.WarningLevelSpecification
{
    public class CadaSimboloDeveReferenciarOutroSimboloSpecification : ISpecification<Simbolo>
    {
        public bool IsSatisfiedBy(Simbolo obj)
        {
            var hasReference = VisualLALMapeamento.Instance.MapaReferencias
                .Any(m => m.SimboloOrigemId.Equals(obj.Id));
            return hasReference;
        }
    }
}

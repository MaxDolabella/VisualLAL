using Maxsys.VisualLAL.CustomCode.Interfaces.Specification;
using System.Linq;

namespace Maxsys.VisualLAL.CustomCode.PrincipioDaCircularidade.Specification.ErrorLevelSpecification
{
    public class CadaSimboloDeveReferenciarOuSerReferenciadoPorOutroSimboloSpecification : ISpecification<Simbolo>
    {
        public bool IsSatisfiedBy(Simbolo obj)
        {
            var hasReference = VisualLALMapeamento.Instance.Referencias
                .Any(m =>
                m.SimboloOrigemId.Equals(obj.Id) ||
                m.SimboloDestinoId.Equals(obj.Id));
            return hasReference;
        }
    }
}

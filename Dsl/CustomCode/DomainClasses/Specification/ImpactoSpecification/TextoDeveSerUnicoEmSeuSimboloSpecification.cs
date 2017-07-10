using Maxsys.VisualLAL.CustomCode.Interfaces.Specification;
using System.Linq;

namespace Maxsys.VisualLAL.CustomCode.DomainClasses.Specification.ImpactoSpecification
{
    public class TextoDeveSerUnicoEmSeuSimboloSpecification : ISpecification<Impacto>
    {
        public bool IsSatisfiedBy(Impacto obj)
        {
            return !obj.Simbolo.Impactos
                .Where(x => !x.Id.Equals(obj.Id))
                .Any(x => x.Texto.Equals(obj.Texto));
        }
    }
}

using Maxsys.VisualLAL.CustomCode.Interfaces.Specification;
using System.Linq;

namespace Maxsys.VisualLAL.CustomCode.DomainClasses.Specification.NocaoSpecification
{
    public class TextoDeveSerUnicoEmSeuSimboloSpecification : ISpecification<Nocao>
    {
        public bool IsSatisfiedBy(Nocao obj)
        {
            return !obj.Simbolo.Nocoes
                .Where(x => !x.Id.Equals(obj.Id))
                .Any(x => x.Texto.Equals(obj.Texto));
        }
    }
}

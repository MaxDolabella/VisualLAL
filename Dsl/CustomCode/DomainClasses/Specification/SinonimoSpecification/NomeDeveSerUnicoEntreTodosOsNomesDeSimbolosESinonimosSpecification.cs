using Maxsys.VisualLAL.CustomCode.Interfaces.Specification;
using System.Linq;

namespace Maxsys.VisualLAL.CustomCode.DomainClasses.Specification.SinonimoSpecification
{
    public class NomeDeveSerUnicoEntreTodosOsNomesDeSimbolosESinonimosSpecification : ISpecification<Sinonimo>
    {
        public bool IsSatisfiedBy(Sinonimo obj)
        {
            var simbolos = obj.Store.ElementDirectory.FindElements<Simbolo>();
            var sinonimos = obj.Store.ElementDirectory.FindElements<Sinonimo>()
                .Where(x => !x.Id.Equals(obj.Id));

            var isSatisfiedBySimbolos = !simbolos.Any(x => x.Nome.Equals(obj.Nome));
            var isSatisfiedBySinonimos = !sinonimos.Any(x => x.Nome.Equals(obj.Nome));

            return isSatisfiedBySimbolos && isSatisfiedBySinonimos;
        }
    }
}

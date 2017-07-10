using Maxsys.VisualLAL.CustomCode.Interfaces.Specification;
using System.Linq;

namespace Maxsys.VisualLAL.CustomCode.DomainClasses.Specification.SimboloSpecification
{
    public class NomeDeveSerUnicoEntreTodosOsNomesDeSimbolosESinonimosSpecification : ISpecification<Simbolo>       
    {
        public bool IsSatisfiedBy(Simbolo obj)
        {
            var sinonimos = obj.Store.ElementDirectory.FindElements<Sinonimo>();
            var simbolos = obj.Store.ElementDirectory.FindElements<Simbolo>()
                .Where(x => x.Id != obj.Id);

            var isSatisfiedBySimbolos = !simbolos.Any(x => x.Nome.Equals(obj.Nome));
            var isSatisfiedBySinonimos = !sinonimos.Any(x => x.Nome.Equals(obj.Nome));

            return isSatisfiedBySimbolos && isSatisfiedBySinonimos;
        }
    }
}

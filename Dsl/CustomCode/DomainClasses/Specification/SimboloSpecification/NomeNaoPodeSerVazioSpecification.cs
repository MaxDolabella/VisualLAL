using Maxsys.VisualLAL.CustomCode.Interfaces.Specification;

namespace Maxsys.VisualLAL.CustomCode.DomainClasses.Specification.SimboloSpecification
{
    public class NomeNaoPodeSerVazioSpecification : ISpecification<Simbolo>
    {
        public bool IsSatisfiedBy(Simbolo obj)
        {
            return !string.IsNullOrWhiteSpace(obj.Nome);
        }
    }
}

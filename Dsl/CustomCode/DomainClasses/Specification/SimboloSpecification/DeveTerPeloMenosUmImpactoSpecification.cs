using Maxsys.VisualLAL.CustomCode.Interfaces.Specification;

namespace Maxsys.VisualLAL.CustomCode.DomainClasses.Specification.SimboloSpecification
{
    public class DeveTerPeloMenosUmImpactoSpecification : ISpecification<Simbolo>
    {
        public bool IsSatisfiedBy(Simbolo obj)
        {
            return obj.Impactos.Count >= 1;
        }
    }
}

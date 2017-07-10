using Maxsys.VisualLAL.CustomCode.Interfaces.Specification;

namespace Maxsys.VisualLAL.CustomCode.DomainClasses.Specification.SimboloSpecification
{
    public class DeveTerPeloMenosUmaNocaoSpecification : ISpecification<Simbolo>
    {
        public bool IsSatisfiedBy(Simbolo obj)
        {
            return obj.Nocoes.Count >= 1;
        }
    }
}

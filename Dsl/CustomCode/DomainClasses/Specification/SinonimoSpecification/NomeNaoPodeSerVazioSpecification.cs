using Maxsys.VisualLAL.CustomCode.Interfaces.Specification;

namespace Maxsys.VisualLAL.CustomCode.DomainClasses.Specification.SinonimoSpecification
{
    public class NomeNaoPodeSerVazioSpecification : ISpecification<Sinonimo>
    {
        public bool IsSatisfiedBy(Sinonimo obj)
        {
            return !string.IsNullOrWhiteSpace(obj.Nome);
        }
    }
}

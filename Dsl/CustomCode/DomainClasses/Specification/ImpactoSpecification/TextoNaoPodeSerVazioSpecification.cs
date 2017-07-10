using Maxsys.VisualLAL.CustomCode.Interfaces.Specification;

namespace Maxsys.VisualLAL.CustomCode.DomainClasses.Specification.ImpactoSpecification
{
    public class TextoNaoPodeSerVazioSpecification : ISpecification<Impacto>
    {
        public bool IsSatisfiedBy(Impacto obj)
        {
            return !string.IsNullOrWhiteSpace(obj.Texto);
        }
    }
}

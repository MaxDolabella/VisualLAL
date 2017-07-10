using Maxsys.VisualLAL.CustomCode.Interfaces.Specification;

namespace Maxsys.VisualLAL.CustomCode.DomainClasses.Specification.NocaoSpecification
{
    public class TextoNaoPodeSerVazioSpecification : ISpecification<Nocao>
    {
        public bool IsSatisfiedBy(Nocao obj)
        {
            return !string.IsNullOrWhiteSpace(obj.Texto);
        }
    }
}

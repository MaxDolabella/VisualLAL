using Maxsys.VisualLAL.CustomCode.Interfaces.Specification;
using Maxsys.VisualLAL.CustomCode.Interfaces.Validation;

namespace Maxsys.VisualLAL.CustomCode.Validation
{
    public class Rule<TEntity> : IRule<TEntity>
    {
        private readonly ISpecification<TEntity> _specificationRule;
        public string ErrorMessage { get; private set; }

        public Rule(ISpecification<TEntity> rule, string errorMessage)
        {
            _specificationRule = rule;
            ErrorMessage = errorMessage;
        }

        public bool Validate(TEntity entity)
        {
            return _specificationRule.IsSatisfiedBy(entity);
        }
    }
}

using Maxsys.VisualLAL.CustomCode.Interfaces.Validation;
using Maxsys.VisualLAL.CustomCode.ValueObjects;
using System.Collections.Generic;

namespace Maxsys.VisualLAL.CustomCode.Validation
{
    public class Validator<TEntity> : IValidator<TEntity> where TEntity : class
    {
        private readonly Dictionary<string, IRule<TEntity>> _validations = new Dictionary<string, IRule<TEntity>>();

        protected virtual void AddRule(string ruleName, IRule<TEntity> rule)
        {
            _validations.Add(ruleName, rule);
        }
        protected virtual void RemoveRule(string ruleName)
        {
            _validations.Remove(ruleName);
        }
        protected IRule<TEntity> GetRule(string ruleName)
        {
            IRule<TEntity> rule;
            _validations.TryGetValue(ruleName, out rule);
            return rule;
        }
        public ValidationResult Validate(TEntity entity)
        {
            var result = new ValidationResult();
            foreach (var x in _validations.Keys)
            {
                var rule = _validations[x];
                if (!rule.Validate(entity))
                    result.AddError(new ValidationError(rule.ErrorMessage));
            }

            return result;
        }
    }
}

using Maxsys.VisualLAL.CustomCode.ValueObjects;

namespace Maxsys.VisualLAL.CustomCode.Interfaces.Validation
{
    public interface IValidator<in TEntity>
    {
        ValidationResult Validate(TEntity entity);
    }
}

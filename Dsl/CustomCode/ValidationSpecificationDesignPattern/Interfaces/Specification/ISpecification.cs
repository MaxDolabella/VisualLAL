namespace Maxsys.VisualLAL.CustomCode.Interfaces.Specification
{
    public interface ISpecification<in TEntity>
    {
        bool IsSatisfiedBy(TEntity obj);
    }
}

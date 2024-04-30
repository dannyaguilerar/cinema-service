using Ardalis.Specification;

namespace Cinema.Core.Interfaces
{
    public interface ISpecRepository<T> : IRepositoryBase<T> where T : class
    {
        
    }
}

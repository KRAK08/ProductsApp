namespace Api.UnitsOfWork.Interfaces
{
    public interface IUnitOfWork<T> where T : class
    {
        Task<T> CreateAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(int id);

        Task<T> GetAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();
    }
}
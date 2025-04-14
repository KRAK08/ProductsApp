using Api.Repositories.Interfaces;
using Api.UnitsOfWork.Interfaces;

namespace Api.UnitsOfWork.Implementations
{
    public class GenericUnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public GenericUnitOfWork(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<T> CreateAsync(T entity) => await _repository.CreateAsync(entity);

        public virtual async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);

        public virtual async Task<IEnumerable<T>> GetAllAsync() => await _repository.GetAllAsync();

        public virtual async Task<T> GetAsync(int id) => await _repository.GetAsync(id);

        public virtual async Task<T> UpdateAsync(T entity) => await _repository.UpdateAsync(entity);
    }
}
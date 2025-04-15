namespace Web.Repository
{
    public interface IRepository
    {
        Task<T> GetAsync<T>(string url, int id);

        Task<List<T>> GetAllAsync<T>(string url);

        Task<T> PostAsync<T>(string url, T entity);

        Task<T> PutAsync<T>(string url, T entity);

        Task DeleteAsync<T>(string url, int id);
    }
}
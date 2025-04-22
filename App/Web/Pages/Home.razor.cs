using Microsoft.AspNetCore.Components;
using Shared.Entities;
using Web.Repository;

namespace Web.Pages
{
    public partial class Home
    {
        [Inject]
        private IRepository repository { get; set; } = null!;

        private List<Product> Products = new();

        protected override async Task OnInitializedAsync()
        {
            await GetListAsync();
        }

        private async Task<List<Product>> GetProducts()
        {
            var result = await repository.GetAllAsync<Product>("api/product");
            return result;
        }

        private async Task GetListAsync()
        {
            var result = await repository.GetAllAsync<Product>("api/product");
            Products = result;
        }

        private async Task Delete(int id)
        {
            await repository.DeleteAsync<Product>("api/product", id);
            await GetListAsync();
        }
    }
}
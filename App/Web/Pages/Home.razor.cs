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
            Products = await GetProducts();
        }

        private async Task<List<Product>> GetProducts()
        {
            var result = await repository.GetAllAsync<Product>("api/product");
            return result;
        }
    }
}
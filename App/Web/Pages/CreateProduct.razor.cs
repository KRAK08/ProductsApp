using Microsoft.AspNetCore.Components;
using Shared.Entities;
using Web.Repository;

namespace Web.Pages
{
    public partial class CreateProduct
    {
        [Inject]
        private IRepository repository { get; set; } = null!;

        private Product product = new Product()
        {
            Image = ""
        };

        [Inject]
        public NavigationManager navigationManager { get; set; } = null!;

        private async Task AddProduct()
        {
            if (product != null)
            {
                await repository.PostAsync<Product>("api/product", product);

                navigationManager.NavigateTo("/", true);
            }
        }
    }
}
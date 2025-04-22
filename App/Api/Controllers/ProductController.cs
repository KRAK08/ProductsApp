using Api.UnitsOfWork.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Shared.Entities;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : GenericController<Product>
    {
        public ProductController(IUnitOfWork<Product> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
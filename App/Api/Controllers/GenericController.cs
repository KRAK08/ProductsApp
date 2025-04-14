using Api.UnitsOfWork.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class GenericController<T> : Controller where T : class
    {
        private readonly IUnitOfWork<T> _unitOfWork;

        public GenericController(IUnitOfWork<T> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _unitOfWork.GetAllAsync());
        }

        [HttpGet("{id:int}")]
        public virtual async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await _unitOfWork.GetAsync(id));
        }

        [HttpPost]
        public virtual async Task<IActionResult> PostAsync(T entity)
        {
            if (entity != null)
            {
                var response = await _unitOfWork.CreateAsync(entity);
                return Ok(response);
            }
            return BadRequest();
        }

        [HttpDelete("{id:int}")]
        public virtual async Task<IActionResult> DeleteAsync(int id)
        {
            await _unitOfWork.DeleteAsync(id);
            return Ok();
        }

        [HttpPut]
        public virtual async Task<IActionResult> PutAsync(T entity)
        {
            var result = await _unitOfWork.UpdateAsync(entity);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
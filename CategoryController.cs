using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InventoryApp.Model;
using InventoryApp.Service;

namespace InventoryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        //[HttpGet]
        //public IActionResult Get([FromQuery] bool? isActive = null)
        //{
        //    return Ok(_categoryService.GetAllCategory(isActive));
        //}

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var hero = _categoryService.GetCategory(id);
            if (hero == null)
            {
                return NotFound();
            }
            return Ok(hero);
        }

        [HttpPost]
        public IActionResult Post(Category category)
        {
            var cat = _categoryService.AddCategory(category);

            if (category == null)
            {
                return BadRequest();
            }

            return Ok(new
            {
                message = "Data Created Successfully!!!",
                id = category!.Id
            });
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] update_category categoryObject)
        {
            var category = _categoryService.UpdateCategory(id, categoryObject);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Data Updated Successfully!!!",
                id = category!.Id
            });
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (!_categoryService.DeleteCategory(id))
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Data Deleted Successfully!!!",
                id = id
            });
        }
    }
}

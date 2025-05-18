using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InventoryApp.Model;
using InventoryApp.Service;

namespace InventoryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        //[HttpGet]
        //public IActionResult Get([FromQuery] bool? isActive = null)
        //{
        //    return Ok(_productService.GetAllProduct(isActive));
        //}

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var product = _productService.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post(update_product productObject)
        {
            var product = _productService.AddProduct(productObject);

            if (product == null)
            {
                return BadRequest();
            }

            return Ok(new
            {
                message = "Data Created Successfully!!!",
                id = product!.Id
            });
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] update_product productObject)
        {
            var product = _productService.UpdateProduct(id, productObject);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "Data Updated Successfully!!!",
                id = product!.Id
            });
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (!_productService.DeleteProduct(id))
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

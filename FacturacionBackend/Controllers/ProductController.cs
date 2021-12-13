using Dto.Request;
using Dto.Response;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Threading.Tasks;

namespace FacturacionBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet]
        [Route("/distinct-product-name")]
        public async Task<IActionResult> GetDistinctProductName()
        {
            return Ok(await _service.GetDistinctProductNameAsync());
        }

        [HttpGet]
        [Route("/sub-product/{productName}")]
        public async Task<IActionResult> GetDistinctProductName(string productName)
        {
            return Ok(await _service.GetAllByProductNameAsync(productName));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductRequestDto product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            ProductResponseDto newProduct = await _service.CreateAsync(product);
            return Created($"/{newProduct.Id}", newProduct);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Put(int id, ProductRequestDto product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            ProductResponseDto newProduct = await _service.UpdateAsync(id, product);
            return Created($"/{newProduct.Id}", newProduct);
        }
    }
}

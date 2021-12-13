using Dto.Request;
using Dto.Response;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Threading.Tasks;

namespace FacturacionBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : ControllerBase
    {
        private IInvoiceService _service;

        public InvoiceController(IInvoiceService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InvoiceRequestDto invoice)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            InvoiceResponseDto newInvoice = await _service.CreateAsync(invoice);

            return Created($"/{newInvoice.Id}", newInvoice);
        }

        [HttpGet]
        [Route("{number}")]
        public async Task<IActionResult> FindByNumber(string number)
        {
            InvoiceResponseDto invoice = await _service.FindByNumberAsync(number);

            if (invoice == null)
                return NotFound();

            return Ok(invoice);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }
    }
}

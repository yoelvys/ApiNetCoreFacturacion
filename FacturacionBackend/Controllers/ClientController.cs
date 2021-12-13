using Dto.Response;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Threading.Tasks;

namespace FacturacionBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private IClientService _service;

        public ClientController(IClientService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet]
        [Route("{dni}")]
        public async Task<IActionResult> Get(string dni)
        {
            ClientResponseDto client = await _service.FindByDNI(dni);

            if (client == null)
                return NotFound();

            return Ok(client);
        }
    }
       
}

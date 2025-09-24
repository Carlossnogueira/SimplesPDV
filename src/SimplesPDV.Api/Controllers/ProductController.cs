using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimplesPDV.Application.Services.Product.Create;
using SimplesPDV.Communication.Request;
using SimplesPDV.Communication.Response;

namespace SimplesPDV.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseProductCreatedJson), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(
            [FromServices] ICreateProductService service,
            [FromBody] RequestProductJson request)
        {
            var response = await service.Execute(request);
            return Created(string.Empty, response);
        }
        
    }
}

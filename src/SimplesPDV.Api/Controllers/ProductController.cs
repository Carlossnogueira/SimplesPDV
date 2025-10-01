using Microsoft.AspNetCore.Mvc;
using SimplesPDV.Application.Services.Product.Create;
using SimplesPDV.Application.Services.Product.GetAll;
using SimplesPDV.Communication.Request;
using SimplesPDV.Communication.Response;
using SimplesPDV.Communication.Response.Front.Pagination;

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

        /*
        [HttpGet]
        [Route("/all")]
        [ProducesResponseType(typeof(AllProductsResponseJson), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromServices] IGetAllProductService service)
        {
            var response = await service.Execute();
            return Ok(response);
        }
        */
        
        [HttpGet]
        [ProducesResponseType(typeof(ResponseProductPaginationJson), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromServices] IGetPaginatedProducts service, int page, int pageSize)
        {
            var response = await service.Execute(page, pageSize);
            return Ok(response);
        }
        
    }
}

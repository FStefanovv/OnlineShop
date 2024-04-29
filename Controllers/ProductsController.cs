using Microsoft.AspNetCore.Mvc;
using EFCoreVezba.Dto;
using EFCoreVezba.Services;
using EFCoreVezba.ApiKeyAuth;
using EFCoreVezba.Exceptions;

[ApiController]
[Route("products")]
public class ProductsController : ControllerBase {
    private readonly IProductService _service;
    private readonly IApiKeyRepository _apiKeyRepository;

    public ProductsController(IProductService service, IApiKeyRepository apiKeyRepo) {
        _service = service;
        _apiKeyRepository = apiKeyRepo;
    }

    [HttpPost]
    [Route("")]
    [CompanyApiKey]
    public ActionResult Add([FromBody] AddProductDTO dto) {
        try {            
            _service.Add(dto, HttpContext.Items["CompanyId"].ToString());
            
            return Ok();
        } catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route("increase-quantity")]
    [CompanyApiKey]
    public ActionResult Add([FromBody] IncreaseQuantityDTO dto) {
        try {
            _service.IncreaseQuantity(dto, HttpContext.Items["CompanyId"].ToString());
            
            return Ok();
        } catch (ForbiddenActionException ex) {
            return StatusCode(403, ex.Message);
        } catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route("add-discount")]
    [CompanyApiKey]
    public ActionResult AddDiscount([FromBody] DiscountDTO dto) {
        var companyId = HttpContext.Items["CompanyId"].ToString();
        
        try {
            _service.AddDiscount(companyId, dto);
            return Ok();
        } catch (ForbiddenActionException ex) {
            return StatusCode(403, ex.Message);
        } catch (Exception ex) {
            return BadRequest(ex.Message);
        }
    }
}
namespace EFCoreVezba.Controller;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

using EFCoreVezba.Dto;
using EFCoreVezba.Services;
using EFCoreVezba.Exceptions;

[ApiController]
[Route("orders")]
public class OrderController : ControllerBase {
    private readonly IOrderService _service;

    public OrderController(IOrderService service) {
        _service = service;
    }

    [HttpPost]
    [Route("")]
    [Authorize]
    public ActionResult Create([FromBody] CreateOrderDTO dto, [FromServices] ILogger<OrderController> logger) {
        var userId = HttpContext.Items["UserId"].ToString();
        var userEmail = HttpContext.Items["UserEmail"].ToString();

        try {
            _service.Create(dto, userId, userEmail);
            return Ok();
        } catch(Exception ex){
            logger.LogError(ex, "An error occurred while processing the request");
            return BadRequest(ex.Message);
        }

    }

    [HttpPut]
    [Route("pay")]
    [Authorize]
    public ActionResult Pay([FromBody] OrderPaymentDTO dto) {
        var userId = HttpContext.Items["UserId"].ToString();

        try {
            _service.Pay(userId, dto);
            return Ok();
        } catch(ForbiddenActionException ex) {
            return StatusCode(403, ex.Message);
        } catch (Exception ex) {
            return BadRequest(ex.Message);          
        }        
    }

}
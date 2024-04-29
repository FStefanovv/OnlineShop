using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

using EFCoreVezba.Dto;
using EFCoreVezba.Services;

namespace EFCoreVezba.Controller;

[ApiController]
[Route("bank-accounts")]
public class BankAccountsController : ControllerBase {
    private readonly IBankAccountService _service;

    public BankAccountsController(IBankAccountService service) {
        _service = service;
    }

    [HttpPost]
    [Route("transfer")]
    [Authorize]
    public ActionResult Transfer([FromBody] MoneyTransferDTO dto){

        try {
            _service.Transfer(HttpContext.Items["UserId"].ToString(), dto.SourceAccountId, dto.DestinationAccountId, dto.Amount, true);
            return Ok();
        } catch (Exception ex){
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route("deposit")]
    public ActionResult Deposit([FromBody] DepositDTO dto) {
        string? userId = HttpContext.Items["UserId"]?.ToString();
        string? userEmail = HttpContext.Items["UserEmail"]?.ToString();
        
        try {
            _service.Deposit(userId, userEmail, dto);
            return Ok();
        } catch (Exception ex){
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route("withdraw")]
    [Authorize]
    public ActionResult Withdraw([FromBody] WithdrawalDTO dto) {
        string userId = HttpContext.Items["UserId"].ToString();

        try {
            _service.Withdraw(userId, dto);
            return Ok();
        } catch(Exception ex) {
            return BadRequest(ex.Message);
        }
    }


    [HttpPut]
    [Route("deactivate/{accountId}")]
    [Authorize]
    public ActionResult Deactivate(string accountId) {
        string userId = HttpContext.Items["UserId"]?.ToString();

        try {
            _service.Deactivate(userId, accountId);
            return Ok();
        } catch(Exception ex) {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route("create")]
    [Authorize]
    public ActionResult Create([FromBody] CreateBankAccountDTO dto) {
        string userId = HttpContext.Items["UserId"].ToString();

        string newBankAccountId = _service.Create(userId, dto);

        return CreatedAtAction(nameof(GetById), new { id = newBankAccountId }, null);
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult GetById(string id)
    {
        try {
            return Ok(_service.GetById(id));
        } catch (Exception ex){
            return NotFound();
        }
    }
}
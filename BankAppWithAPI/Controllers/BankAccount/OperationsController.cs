using Azure;
using BankAppWithAPI.Dtos.Operation;
using BankAppWithAPI.Models;
using BankAppWithAPI.Services.OperationService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankAppWithAPI.Controllers.BankAccount
{
    [ApiController]
    [Route("[controller]")]
    public class OperationsController(IOperationService _operationService) : ControllerBase
    {
        [HttpPost("deposit")]
        [Authorize(AuthenticationSchemes = "MyTokenScheme")]
        public async Task<ActionResult<ServiceResponse<OperationResultDto>>> Deposit(int amount)
        {
            var response = await _operationService.Deposit(amount, User);

            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPost("withdraw")]
        [Authorize(AuthenticationSchemes = "MyTokenScheme")]
        public async Task<ActionResult<ServiceResponse<OperationResultDto>>> Withdraw(int amount)
        {
            var response = await _operationService.Withdraw(amount, User);

            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPost("transfer")]
        public async Task<ActionResult<ServiceResponse<TransferRequestDto>>> Transfer(TransferRequestDto request)
        {
            var response = await _operationService.Transfer(request, User);

            return StatusCode((int)response.StatusCode, response);
        }
    }
}

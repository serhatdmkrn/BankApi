﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using BankAppWithAPI.Dtos.User;
using Microsoft.AspNetCore.Mvc;
using BankAppWithAPI.Data;
using BankAppWithAPI.Models;
using BankAppWithAPI.Services.BankAccountService;
using BankAppWithAPI.Dtos.BankAccount;
using Azure;

namespace BankAppWithAPI.Controllers.BankAccount
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class BankAccountController(IBankAccountService bankAccountService) : ControllerBase
    {
        [HttpPost("create")]
        public async Task<ActionResult<ServiceResponse<GetBankAccountDto>>> CreateBankAccount(CreateBankAccountDto createBankAccountDto)
        {
            var response = await bankAccountService.CreateBankAccount(createBankAccountDto, User);

            return StatusCode((int)response.StatusCode, response);
        }

        [HttpGet("myAccounts")]
        public async Task<ActionResult<ServiceResponse<List<GetBankAccountDto>>>> GetBankAccounts()
        {
            var response = await bankAccountService.GetUserBankAccounts(User);

            return StatusCode((int)response.StatusCode, response);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<GetBankAccountDto>>> GetConcreteBankAccount()
        {
            var response = await bankAccountService.GetConcreteBankAccount(User);

            return StatusCode((int)response.StatusCode, response);
        }
    }
}

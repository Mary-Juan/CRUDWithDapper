﻿using CRUDWithDapper.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDWithDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {

        private IBankRepository _bankRepository;

        public BankController(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        [HttpGet("GetAllBanks")]
        public async Task<IActionResult> GetAllBanks()
        {
            var res = await _bankRepository.GetAllAsync();
            return Ok(res);
        }
    }
}

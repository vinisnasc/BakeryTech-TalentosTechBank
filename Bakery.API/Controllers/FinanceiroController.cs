using Bakery.Model;
using Bakery.Model.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bakery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinanceiroController : ControllerBase
    {
        private readonly IFinanceiroService _financeiroService;

        public FinanceiroController(IFinanceiroService financeiroService)
        {
            _financeiroService = financeiroService;
        }
      
        [HttpGet]
        public IActionResult Get()
        {
            var financeiro = _financeiroService.SelecionarPorId();
            return Ok(financeiro);
        }
    }
}

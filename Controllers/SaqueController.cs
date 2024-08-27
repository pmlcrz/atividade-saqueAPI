using Microsoft.AspNetCore.Mvc;
using Saque.Models;
using Saque.Services;

namespace Saque.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaqueController : ControllerBase
    {
        private readonly ContaService _service;

        public SaqueController()
        {
            _service = new ContaService();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Conta>> GetContas()
        {
            return Ok(_service.GetAll());
        }

        [HttpPost("saque")]
        public IActionResult Saque(int id, decimal valor)
        {
            var sucesso = _service.Saque(id, valor);
            if (sucesso)
            {
                return Ok(new { Mensagem = "Saque realizado com sucesso" });
            }
            return BadRequest(new { Mensagem = "Saldo insuficiente ou conta não encontrada" });
        }

        [HttpPost("deposito")]
        public IActionResult Deposito(int id, decimal valor)
        {
            _service.Deposito(id, valor);
            return Ok(new { Mensagem = "Depósito realizado com sucesso" });
        }
    }
}

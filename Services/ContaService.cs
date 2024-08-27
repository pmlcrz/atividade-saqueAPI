using Saque.Models;
using System.Collections.Generic;
using System.Linq;

namespace Saque.Services
{
    public class ContaService
    {
        private readonly List<Conta> _contas;

        public ContaService()
        {
            _contas = new List<Conta>
            {
                new Conta { Id = 1, Titular = "Monteiro do Val", Tipo = TipoConta.PessoaFisica, Saldo = 1000 },
                new Conta { Id = 2, Titular = "Empresa Vale do silicio", Tipo = TipoConta.PessoaJuridica, Saldo = 5000 }
            };
        }

        public List<Conta> GetAll() => _contas;

        public Conta? GetById(int id) => _contas.FirstOrDefault(c => c.Id == id);


        public bool Saque(int id, decimal valor)
        {
            var conta = GetById(id);
            if (conta != null && conta.Saldo >= valor)
            {
                conta.Saldo -= valor;
                return true;
            }
            return false;
        }

        public void Deposito(int id, decimal valor)
        {
            var conta = GetById(id);
            if (conta != null)
            {
                conta.Saldo += valor;
            }
        }
    }
}

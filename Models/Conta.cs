namespace Saque.Models
{
    public class Conta
    {
        public int Id { get; set; }
        public string Titular { get; set; } = string.Empty;

        public TipoConta Tipo { get; set; }
        public decimal Saldo { get; set; }
    }
}

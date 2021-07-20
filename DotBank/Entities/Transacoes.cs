using System;

namespace DotBank.Entities
{
    public class Transacoes
    {
        public Transacoes(double valor)
        {
            Transacao = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
            Data = DateTime.Now;
            Valor = valor;
        }

        public string Transacao { get; private set; }
        public double Valor { get; private set; }
        public DateTime Data { get; private set; }

        public void ExibirTransacao()
        {
            Console.WriteLine($"Identificador: {Transacao} | Valor: {Valor} | Data: {Data:HH:mm:ss dd/MM/yyyy}");
        }
    }
}
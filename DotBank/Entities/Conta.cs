using System;
using System.Collections.Generic;
using DotBank.Enums;

namespace DotBank.Entities
{
    public class Conta
    {
        static int incrementadorId = 0;

        public Conta(string nome, TipoContas tipoConta, string documento, double saldo, double credito)
        {
            var random = new Random();

            Id = incrementadorId;
            Numero = random.Next(999999);
            Agencia = (uint)random.Next(9999);
            Nome = nome;
            TipoConta = tipoConta;
            Documento = documento;
            Credito = credito;
            Saldo = saldo;

            ExtratoTransacoes = new List<Transacoes>();
            incrementadorId++;
        }

        public int Id { get; private set; }
        public int Numero { get; private set; }
        public uint Agencia { get; private set; }
        public string Nome { get; private set; }
        public double Saldo { get; private set; }
        public double Credito { get; private set; }
        public TipoContas TipoConta { get; private set; }
        public string Documento { get; private set; }
        public List<Transacoes> ExtratoTransacoes { get; private set; }

        public void RealizarSaque(double valor)
        {
            if(!Sacar(valor))
            {
                Console.WriteLine("Saldo e Créditos insuficientes");
                return;
            }

            Console.WriteLine($"Saque realizado com sucesso");
            InformativoConta();
        }

        private bool Sacar(double valor)
        {
            if(valor > Saldo + Credito)
                return false;

            ExtratoTransacoes.Add(new Transacoes(valor * -1));
            Saldo -=valor;
            return true;
        }

        public void RealizarDepositivo(double valor)
        {
            Depositar(valor);
            Console.WriteLine($"Depósito realizado com sucesso");
            InformativoConta();
        }

        private void Depositar(double valor)
        {
            ExtratoTransacoes.Add(new Transacoes(valor));
            Saldo += valor;
        }

        public void RealizarTransferencia(double valor, Conta cedente)
        {
            if(!Sacar(valor))
            {
                Console.WriteLine("Saldo insuficiente para realizar essa transferência");
                return;
            }

            cedente.Depositar(valor);
            Console.WriteLine("Transferência realizada com sucesso");
        }

        public void InformativoConta()
            => Console.WriteLine($"Numero: {Numero} | Nome: {Nome} | Saldo: R$ {Saldo:N2} | Crédito: R$ {Credito:N2}");

        public void ExibirExtrato()
        {
            foreach(var extrato in ExtratoTransacoes)
                extrato.ExibirTransacao();
        }
    }
}
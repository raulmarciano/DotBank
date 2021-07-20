using System;
using System.Collections.Generic;
using DotBank.Entities;
using DotBank.Enums;

namespace DotBank
{
    public class Program
    {
        public static List<Conta> contas = new List<Conta>();

        static void Main(string[] args)
        {
            string opcaoSelecionada = "";

            while(opcaoSelecionada != "S")
            {
                MontarOpcoes();

                Console.Write("Opcao: ");
                opcaoSelecionada = Console.ReadLine().ToUpper();

                switch (opcaoSelecionada)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        CriarConta();
                        break;
                    case "3":
                        ConsultarExtrato();
                        break;
                    case "4":
                        ConsultarSaldo();
                        break;
                    case "5":
                        RealizarSaque();
                        break;
                    case "6":
                        RealizarDeposito();
                    break;
                    case "7":
                        RealizarTransferencia();
                        break;

                    case "C":
                        Console.Clear();
                        break;
                    case "S":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Informe uma opção válida");
                        break;
                }
            };
        }

        private static void ConsultarExtrato()
        {
            Console.Write(Environment.NewLine);
            Console.WriteLine("Consulta de extrato");
            var id = SelecionarConta();
            contas[id].ExibirExtrato();

            MensagemVoltarMenu();
        }

        private static void ConsultarSaldo()
        {
            Console.Write(Environment.NewLine);
            Console.WriteLine("Consulta de saldo");
            Console.Write(Environment.NewLine);
            var id = SelecionarConta();
            contas[id].InformativoConta();

            MensagemVoltarMenu();
        }

        private static void RealizarTransferencia()
        {
            Console.Write(Environment.NewLine);
            Console.WriteLine("Transferencia");
            Console.Write(Environment.NewLine);

            var id = SelecionarConta();

            Console.WriteLine("Digite o identificador da conta para qual irá o valor da transferência");
            var idCedente = Convert.ToInt32(Console.ReadLine());

            Console.Write("Informe o valor no qual deseja transferir: ");
            double valor = Convert.ToDouble(Console.ReadLine());

            var teste = contas[idCedente];

            contas[id].RealizarTransferencia(valor, teste);
            MensagemVoltarMenu();
        }

        private static void RealizarDeposito()
        {
            Console.Write(Environment.NewLine);
            Console.WriteLine("Deposito");
            Console.Write(Environment.NewLine);

            var id = SelecionarConta();
            Console.Write("Informe o valor no qual deseja depositar: ");
            double valor = Convert.ToDouble(Console.ReadLine());

            contas[id].RealizarDepositivo(valor);

            MensagemVoltarMenu();
        }

        private static void RealizarSaque()
        {
            Console.Write(Environment.NewLine);
            Console.WriteLine("Saque");
            Console.Write(Environment.NewLine);

            var id = SelecionarConta();
            Console.Write("Informe o valor no qual deseja sacar: ");
            double valor = Convert.ToDouble(Console.ReadLine());

            contas[id].RealizarSaque(valor);

            MensagemVoltarMenu();
        }

        private static int SelecionarConta()
        {
            Console.Write(Environment.NewLine);
            Console.Write("Digite o identificador da conta na qual deseja realizar a transação: ");
            var idConta = Convert.ToInt32(Console.ReadLine());            
            Console.WriteLine(Environment.NewLine);

            return idConta;
        }

        public static void MontarOpcoes()
        {
            Console.WriteLine($"{Environment.NewLine}DotBank{Environment.NewLine}{Environment.NewLine}");    

            Console.WriteLine($"Selecione alguma opção:{Environment.NewLine}");

            Console.WriteLine("1 - Lista Contas");
            Console.WriteLine("2 - Criar Conta");
            Console.WriteLine("3 - Consultar Extrato");
            Console.WriteLine("4 - Consultar Saldo");
            Console.WriteLine("5 - Sacar");
            Console.WriteLine("6 - Depositar ");
            Console.WriteLine("7 - Transferir ");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("S - Sair");
        }

        public static void CriarConta()
        {
            Console.Write(Environment.NewLine);
            Console.WriteLine("Criação de conta");
            Console.Write(Environment.NewLine);

            Console.Write("Nome: ");
            var nome = Console.ReadLine();
            Console.Write("Tipo Conta   1 - Física   2 - Juridica: ");
            var tipoConta = (TipoContas)Convert.ToInt32(Console.ReadLine());
            Console.Write("Documento: ");
            var documento = Console.ReadLine();
            Console.Write("Saldo Inicial: ");
            var saldo = Convert.ToDouble(Console.ReadLine());
            Console.Write("Credito: ");
            var credito = Convert.ToDouble(Console.ReadLine());

            contas.Add(new Conta(nome, tipoConta, documento, saldo, credito));

            Console.WriteLine($"Conta criada com sucesso");
            MensagemVoltarMenu();
        }

        public static void MensagemVoltarMenu()
        {
            Console.Write(Environment.NewLine);
            Console.Write("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
            Console.Write(Environment.NewLine);
        }

        public static void ListarContas()
        {
            Console.Write(Environment.NewLine);
            Console.WriteLine("Listagem de contas");
            Console.Write(Environment.NewLine);

            if(contas.Count == 0)
                Console.WriteLine("Nenhuma conta registrada");

            foreach(var conta in contas)
            {
                Console.Write($"Identificador: {conta.Id}");
                Console.Write($" | Nome: {conta.Nome}");
                Console.Write($" | Tipo Conta: {(conta.TipoConta == TipoContas.Fisica ? "Pessoa Física" : "Pessoa Juridica")}");
                Console.Write($" | Documento: {conta.Documento}");
                Console.Write($" | Numero: {conta.Numero}");
                Console.Write($" | Agência: {conta.Agencia}");
                Console.Write($" | Saldo: R$ {conta.Saldo:N2}");
                Console.Write($" | Crédito: R$ {conta.Credito:N2}");
                Console.Write(Environment.NewLine);
            }

            MensagemVoltarMenu();
        }
    }
}

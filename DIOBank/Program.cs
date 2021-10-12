using System;
using System.Globalization;
using System.Collections.Generic;
using DIOBank.Classes;
using DIOBank.Enums;

namespace DIOBank
{
    class Program
    {
        static List<Conta> Contas  = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoEscolhida = ObterOpcaoUsuario();

            while(opcaoEscolhida != "X")
            {
                switch (opcaoEscolhida)
                {
                    case "1":
                        //TODO - listar contas
                        ListarContas();
                        break;
                    case "2":
                        //TODO - inserir nova conta
                        InserirConta();
                        break;
                    case "3":
                        //TODO - transferir
                        //Transferir();
                        break;
                    case "4":
                        //TODO - sacar
                        //Sacar();
                        break;
                    case "5":
                        //TODO - depositar
                        //Depositar();
                        break;
                    case "6":
                        //TODO - limpar tela
                        Console.Clear();
                        ObterOpcaoUsuario();
                        break;
                    case "X":
                        //TODO - sair
                        break;
                    default:
                        Console.WriteLine("Opção Inválida, tente novamente!");
                        break;
                }

                opcaoEscolhida = ObterOpcaoUsuario();

            }

        }

        private static void ListarContas()
        {
            Console.WriteLine(" *** LISTAR CONTAS ***\n");

            if (Contas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada!");
                return;
            }

            Console.WriteLine($"{Contas.Count} - conta(s) cadastrada(s)");
            foreach(var conta in Contas)
            {
                Console.WriteLine(conta);
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine(" *** INSERIR NOVA CONTA ***\n");
            Console.WriteLine("Informe os dados solicitados abaixo\n");

            Console.Write("Digite 1 para Conta Pessoa Física ou 2 para Jurídica .: ");
            int tipoConta = int.Parse(Console.ReadLine());

            Console.Write("NOME ..........: ");
            string nome = Console.ReadLine();

            Console.Write("SALDO INICIAL .: R$ ");
            double saldo = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("CRÉDITO .......: R$ ");
            double credito = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Conta novaConta = new Conta((TipoConta)tipoConta, saldo, credito, nome);

            Contas.Add(novaConta);

        }

        private static string ObterOpcaoUsuario()
        {

            Console.WriteLine($"\nDIO Bank a seu dispor!");
            Console.WriteLine("Escolha uma das opções abaixo.");
            Console.WriteLine($"1 - Listar contas");
            Console.WriteLine($"2 - Inserir nova conta");
            Console.WriteLine($"3 - Transferir");
            Console.WriteLine($"4 - Sacar");
            Console.WriteLine($"5 - Depositar");
            Console.WriteLine($"6 - Limpar Tela");
            Console.WriteLine($"X - Sair");
            Console.WriteLine($"Informe a opção desejada:");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return opcaoUsuario;

        }
    }
}

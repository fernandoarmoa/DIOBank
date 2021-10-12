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
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "6":
                        Console.Clear();
                        ObterOpcaoUsuario();
                        break;
                    case "X":
                        break;
                    default:
                        AlteraCor('r');
                        Console.WriteLine("Opção Inválida, tente novamente!");
                        AlteraCor('d');
                        break;
                }

                opcaoEscolhida = ObterOpcaoUsuario();

            }

        }

        private static void Transferir()
        {
            AlteraCor('y');
            Console.WriteLine(" *** TRANSFERIR ***\n");
            AlteraCor('d');

            if (!ExisteContas())
                return;

            Console.WriteLine("CONTA DE ORIGEM");
            int numeroDaContaDeOrigem = RetornarNumeroDaConta();

            Console.WriteLine("\nCONTA DE DESTINO");
            int numeroDaContaDeDestino = RetornarNumeroDaConta();

            double quantia = RetornarQuantia();

            Contas[numeroDaContaDeOrigem].Transferir(Contas[numeroDaContaDeDestino], quantia);

            Contas[numeroDaContaDeOrigem].MostraSaldoAtual();

        }

        private static void Sacar()
        {
            AlteraCor('y');
            Console.WriteLine(" *** SACAR ***\n");
            AlteraCor('d');

            if (!ExisteContas())
                return;

            int numeroDaConta = RetornarNumeroDaConta();

            double quantia = RetornarQuantia();

            Contas[numeroDaConta].Sacar(quantia);

            Contas[numeroDaConta].MostraSaldoAtual();

        }

        private static void Depositar()
        {
            AlteraCor('y');
            Console.WriteLine(" *** DEPOSITAR ***\n");
            AlteraCor('d');

            if (!ExisteContas())
                return;

            int numeroDaConta = RetornarNumeroDaConta();

            double quantia = RetornarQuantia();

            Contas[numeroDaConta].Depositar(quantia);

            Contas[numeroDaConta].MostraSaldoAtual();
            
        }

        private static bool ExisteContas()
        {
            if (Contas.Count == 0)
            {
                AlteraCor('r');
                Console.WriteLine("Nenhuma conta cadastrada!");
                AlteraCor('d');
                return false;
            }

            return true;
        }

        private static void ListarContas()
        {
            AlteraCor('y');
            Console.WriteLine(" *** LISTAR CONTAS ***\n");
            AlteraCor('d');

            if (!ExisteContas())
                return;

            Console.WriteLine($"{Contas.Count} - conta(s) cadastrada(s)");
            foreach(var conta in Contas)
            {
                Console.WriteLine(conta);
            }
        }

        private static void InserirConta()
        {
            try
            {
                AlteraCor('y');
                Console.WriteLine(" *** INSERIR NOVA CONTA ***\n");
                Console.WriteLine("Informe os dados solicitados abaixo\n");
                AlteraCor('d');

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
            catch (FormatException fe)
            {
                Console.WriteLine("Caracter digitado errado!");
                Console.WriteLine(fe.Message);
            }
            finally
            {
                Console.Clear();
                ObterOpcaoUsuario();
            }

        }

        private static double RetornarQuantia()
        {
            try
            {
                Console.Write("INFORME A QUANTIA .....: ");
                return double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        private static int RetornarNumeroDaConta()
        {
            try
            {
                Console.Write("INFORME O Nº DA CONTA .: ");
                return (int.Parse(Console.ReadLine()) - 1);
            }
            catch (FormatException fe)
            {
                Console.WriteLine("Caracter digitado errado!");
                Console.WriteLine(fe.Message);
                return 6;
            }
        }

        private static void AlteraCor(char cor)
        {
            switch (cor)
            {
                case 'y':
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case 'g':
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 'b':
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case 'r':
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    Console.ResetColor();
                    break;
            }
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
            Console.WriteLine($"X - Sair\n");
            Console.Write($"Informe a opção desejada: ");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return opcaoUsuario;

        }
    }
}

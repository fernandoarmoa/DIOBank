using System;
using System.Globalization;
using DIOBank.Enums;
using System.Text;

namespace DIOBank.Classes
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public void Sacar(double valorSaque)
        {
            if (VerificarLimite(valorSaque))
            {
                this.Saldo -= valorSaque;
            }

        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
        }

        public void Transferir(Conta contaDestino, double valorTransferencia)
        {
            if (VerificarLimite(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
                this.Saldo -= valorTransferencia;
            }
        }

        private bool VerificarLimite(double quantia)
        {
            if (this.Saldo - quantia < (this.Credito * -1))
            {
                Console.WriteLine("Saldo insuficiente");
                return false;
            }

            return true;
        }

        public void MostraSaldoAtual()
        {
            Console.WriteLine($"Saldo atual da conta de {this.Nome} é R$ {this.Saldo.ToString("F2", CultureInfo.InvariantCulture)}");
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"TIPO CONTA .: {this.TipoConta}\t| NOME .: {this.Nome.ToUpper()}");
            sb.AppendLine($"SALDO ......: R$ {this.Saldo.ToString("F2", CultureInfo.InvariantCulture)} -- CRÉDITO .: R$ {this.Credito.ToString("F2", CultureInfo.InvariantCulture)}");
            return sb.ToString();
        }

    }
}
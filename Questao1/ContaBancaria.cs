using System;
using System.Drawing;
using System.Globalization;

namespace Questao1
{
    class ContaBancaria {

        const double TaxaSaque = 3.5;
        public ContaBancaria(string numeroConta, string titular, string saldo)
        {
            NumeroConta = ValidaNumeroConta(numeroConta);
            Titular = titular;
            Saldo = ValidaValor(saldo);
        }

        public ContaBancaria(string numeroConta, string titular) {
            NumeroConta = ValidaNumeroConta(numeroConta);
            Titular = titular;
        }

        public void Deposito(string valor)
        {
            Saldo += ValidaValor(valor);
        }

        public void Saque(string valor)
        {            
            Saldo -= (ValidaValor(valor) + TaxaSaque);
        }

        private int ValidaNumeroConta(string numero)
        {
            if (!int.TryParse(numero, out int numeroContaConvertido))
                throw new Exception("O valor informado é inválido (somente números são permitidos)");

            return numeroContaConvertido;
        }

        private double ValidaValor(string valor)
        {
            if (!double.TryParse(valor, out double valorConvertido))
                throw new Exception("O valor informado é inválido (somente números são permitidos)");

            if (valorConvertido <= 0)            
                throw new ArgumentException("O valor informado é inválido (somente valores positivos são permitidos)");

            return valorConvertido;
        }

        private int NumeroConta { get; set;}
        public string Titular { get; set; }
        private double Saldo { get; set; }

        public override string ToString()
        {
            return string.Format("Conta: {0}, Titular: {1}, Saldo: ${2}", NumeroConta, Titular, Saldo.ToString("n2"));
        }
    }
}

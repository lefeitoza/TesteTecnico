using System;
using System.Globalization;

namespace Questao1 {
    class Program {
        static void Main(string[] args) {

            ContaBancaria conta;
            try
            {
                Console.Write("Entre o número da conta: ");
                var numero = Console.ReadLine();
                Console.Write("Entre o titular da conta: ");
                var titular = Console.ReadLine();
                Console.Write("Haverá depósito inicial (s/n)? ");
                var resp = char.Parse(Console.ReadLine());
                if (resp.ToString().ToLower().Equals("s"))
                {
                    Console.Write("Entre o valor de depósito inicial: ");
                    var depositoInicial = Console.ReadLine();
                    conta = new ContaBancaria(numero, titular, depositoInicial);
                }
                else
                    conta = new ContaBancaria(numero, titular);                

                Console.WriteLine();
                Console.WriteLine("Dados da conta:");
                Console.WriteLine(conta);

                Console.WriteLine();
                Console.Write("Entre um valor para depósito: ");
                var quantia = Console.ReadLine();
                conta.Deposito(quantia);
                Console.WriteLine("Dados da conta atualizados:");
                Console.WriteLine(conta);

                Console.WriteLine();
                Console.Write("Entre um valor para saque: ");
                quantia = Console.ReadLine();
                conta.Saque(quantia);
                Console.WriteLine("Dados da conta atualizados:");
                Console.WriteLine(conta);
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Houve um erro, por favor verifique.\nDescrição do erro: {0}", ex.Message));
            }
            

            /* Output expected:
            Exemplo 1:

            Entre o número da conta: 5447
            Entre o titular da conta: Milton Gonçalves
            Haverá depósito inicial(s / n) ? s
            Entre o valor de depósito inicial: 350.00

            Dados da conta:
            Conta 5447, Titular: Milton Gonçalves, Saldo: $ 350.00

            Entre um valor para depósito: 200
            Dados da conta atualizados:
            Conta 5447, Titular: Milton Gonçalves, Saldo: $ 550.00

            Entre um valor para saque: 199
            Dados da conta atualizados:
            Conta 5447, Titular: Milton Gonçalves, Saldo: $ 347.50

            Exemplo 2:
            Entre o número da conta: 5139
            Entre o titular da conta: Elza Soares
            Haverá depósito inicial(s / n) ? n

            Dados da conta:
            Conta 5139, Titular: Elza Soares, Saldo: $ 0.00

            Entre um valor para depósito: 300.00
            Dados da conta atualizados:
            Conta 5139, Titular: Elza Soares, Saldo: $ 300.00

            Entre um valor para saque: 298.00
            Dados da conta atualizados:
            Conta 5139, Titular: Elza Soares, Saldo: $ -1.50
            */
        }
    }
}

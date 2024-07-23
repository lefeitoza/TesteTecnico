namespace Questao5.Domain.Entities.Response
{
    /// <summary>
    /// Representa o retorno de dados bancários de um cliente com o saldo da conta.
    /// </summary>
    public class AccountBalanceResponse : ResultBase
    {
        /// <summary>
        /// Número da conta
        /// </summary>
        public int AccountNumber { get; set; }

        /// <summary>
        /// Nome do Cliente
        /// </summary>
        public string ClientName { get; set; }

        /// <summary>
        /// Data da consulta
        /// </summary>
        public DateTime RequestDate { get; set; }

        /// <summary>
        /// Saldo atual
        /// </summary>
        public double AccountBalance { get; set; }
    }
}

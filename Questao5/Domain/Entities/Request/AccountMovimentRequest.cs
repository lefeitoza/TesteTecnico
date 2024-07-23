namespace Questao5.Domain.Entities.Request
{
    /// <summary>
    /// Representa uma movimentação em conta
    /// </summary>
    public class AccountMovimentRequest
    {

        /// <summary>
        /// Identificação da requisição  
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Identificação da conta corrente
        /// </summary>
        public int AccountNumber { get; set; }

        /// <summary>
        /// Valor a ser movimentado
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Tipo de movimento (C - Crédito D - Débito)
        /// </summary>
        public string MovimentType { get; set; }
    }
}

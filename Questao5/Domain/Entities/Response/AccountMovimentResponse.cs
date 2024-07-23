namespace Questao5.Domain.Entities.Response
{
    /// <summary>
    /// Representa o retorno de uma movimentação em conta realizada com sucesso
    /// </summary>
    public class AccountMovimentResponse : ResultBase
    {        
        /// <summary>
        /// Id da movimentação da conta
        /// </summary>
        public string MovimentId { get; set; }        
    }
}

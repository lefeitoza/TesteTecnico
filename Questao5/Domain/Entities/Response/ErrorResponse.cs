namespace Questao5.Domain.Entities.Response
{
    /// <summary>
    /// Representra um erro gerado pelas validações de regras de negócios
    /// </summary>
    public class ErrorResponse : ResultBase
    {
        /// <summary>
        /// Descrição do erro
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Tipo do erro
        /// </summary>
        public string Type { get; set; }
    }
}

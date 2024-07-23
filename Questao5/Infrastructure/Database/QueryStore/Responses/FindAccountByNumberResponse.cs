namespace Questao5.Infrastructure.Database.QueryStore.Responses
{
    public class FindAccountByNumberResponse
    {
        public string Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}

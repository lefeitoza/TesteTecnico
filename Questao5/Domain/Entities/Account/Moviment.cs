namespace Questao5.Domain.Entities.Account
{
    public class Moviment 
    {
        public string Id { get; set; }
        public string IdCheckingAccount { get; set; }
        public DateTime Date { get; set; }
        public string MovimentType { get; set; }
        public double Value { get; set; }
    }
}

namespace GeradorDeApostas.Models
{
    public class BetResult
    {
        public int Id { get; set; }
        public string Result { get; set; }
        public Bet Bet { get; set; }    
    }
}

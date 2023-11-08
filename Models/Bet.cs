namespace GeradorDeApostas.Models
{
    public class Bet
    {
        public int Id { get; set; } 
        public int qtGames { get; set; }
        public int numberGames { get; set; }
        public string resultGames { get; set; }
        public bool error { get; set; }
      
    }
}

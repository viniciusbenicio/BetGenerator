namespace GeradorDeApostas.Models
{
    public class Bet
    {
        public int Id { get; set; } 
        public int NumberOfGames { get; set; }
        public int TotalNumbers { get; set; }
        public string resultGames { get; set; }
        public bool error { get; set; }
      
    }
}

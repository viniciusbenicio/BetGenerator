using GeradorDeApostas.Models;

namespace GeradorDeApostas.Repository
{
    public interface IBetRepository
    {

        IEnumerable<Bet> GetBets();
        Task<Bet> GetBetsByIdAsync(int Id);
        Task PostBetsAsync(Bet bet);
        Task SaveAsync();
        Task<Bet> GenerateBetAsync(int totalNumber, int? numberOfGames);
    }
}

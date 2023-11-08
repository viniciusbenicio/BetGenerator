using GeradorDeApostas.Models;

namespace GeradorDeApostas.Repository
{
    public interface IBetRepository
    {

        IEnumerable<Bet> GetBets();
        Task<Bet> GetBetsByIdAsync(int Id);
        Task PostBetsAsync(Bet bet);
        Task SaveAsync();
        Bet GenerateBet(int totalNumber);
    }
}

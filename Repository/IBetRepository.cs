using GeradorDeApostas.Models;

namespace GeradorDeApostas.Repository
{
    public interface IBetRepository
    {

        IEnumerable<Bet> GetBets();
        public Bet GetBetsById(int Id);
        void PostBets(Bet bet);
        public void Save();
    }
}

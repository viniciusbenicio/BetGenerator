using GeradorDeApostas.Data.Mappings;
using GeradorDeApostas.Models;

namespace GeradorDeApostas.Repository
{
    public class BetRepository : IBetRepository
    {
        private readonly ApostasDBContext _context;
        public BetRepository(ApostasDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Bet> GetBets()
        {
            return _context.bets.ToList();
        }

        public Bet GetBetsById(int Id)
        {
            return _context.bets.Find(Id);
        }

        public void PostBets(Bet bet)
        {
            _context.bets.Add(bet);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
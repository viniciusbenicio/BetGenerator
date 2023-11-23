using GeradorDeApostas.Data.Mappings;
using GeradorDeApostas.Models;
using Microsoft.EntityFrameworkCore;

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
            return _context.bets.Include(x => x.BetResults).ToList();
        }

        public async Task<Bet> GetBetsByIdAsync(int Id)
        {
            return await _context.bets.Include(x => x.BetResults).FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task PostBetsAsync(Bet bet)
        {
            await _context.bets.AddAsync(bet);
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Bet> GenerateBetAsync(int totalNumber, int? numberOfGames)
        {
            Random random = new Random();
            Bet bet = new Bet()
            {
                TotalNumbers = totalNumber,
                NumberOfGames = numberOfGames ?? 1
            };
            int[] numerosAleatorios = new int[15];
            string result = "";

            if (totalNumber < 6 || totalNumber > 15)
                bet.Error = true;

            if (numberOfGames >= 1 && numberOfGames <= 10)
            {
                for (int n = 0; n < numberOfGames; n++)
                {
                    for (int i = 0; i <= totalNumber; i++)
                        numerosAleatorios[i] = random.Next(1, 61);

                    foreach (int j in numerosAleatorios)
                    {
                        if (j != 0)
                        {
                            bet.Error = false;
                            result += $"{j};";
                            if (bet.BetResults == null)
                            {
                                bet.BetResults = new List<BetResult>();
                            }
                        }
                        else
                            continue;
                    }

                    bet.BetResults.Add(new BetResult {Result = result});
                    await this.PostBetsAsync(bet);
                    result = "";

                }
            }
            else
            {
                bet.Error = true;
            }

            await this.SaveAsync();

            return bet;
        }
    }
}
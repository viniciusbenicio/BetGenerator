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

            if (totalNumber < 6 || totalNumber > 15)
                bet.Error = true;

            if (numberOfGames >= 1 && numberOfGames <= 10)
            {
                for (int n = 0; n < numberOfGames; n++)
                {
                    int[] numerosAleatorios = new int[totalNumber];
                    string result = "";

                    for (int i = 0; i < totalNumber; i++)
                    {
                        int numeroAleatorio;
                        do
                        {
                            numeroAleatorio = random.Next(1, 61);
                        } while (numerosAleatorios.Contains(numeroAleatorio));

                        numerosAleatorios[i] = numeroAleatorio;
                    }

                    foreach (int j in numerosAleatorios)
                    {
                        result += $"{j};";

                        if (bet.BetResults == null)
                        {
                            bet.BetResults = new List<BetResult>();
                        }
                    }

                    bet.BetResults.Add(new BetResult { Result = result });
                    await this.PostBetsAsync(bet);
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
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

        public  IEnumerable<Bet> GetBets()
        {
            return  _context.bets.ToList();
        }

        public async Task<Bet> GetBetsByIdAsync(int Id)
        {
            return await _context.bets.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task PostBetsAsync(Bet bet)
        {
            await _context.bets.AddAsync(bet);
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public Bet GenerateBet(int totalNumber)
        {
            Random random = new Random();
            int[] numerosAleatorios = new int[15];

            Bet bet = new Bet()
            {
                numberGames = 1,
                qtGames = totalNumber
            };

            if (totalNumber < 6 || totalNumber > 15)
            {
                bet.error = true;
                bet.resultGames = $"A quantidade de numeros para gerar a aposta é menor que 6 ou maior que 15, valor informado :{totalNumber}";
            }
            else
            {
                for (int i = 0; i < totalNumber; i++)
                    numerosAleatorios[i] = random.Next(1, 61);

                foreach (int j in numerosAleatorios)
                    if (j != 0)
                        bet.resultGames += $"{j};";
                    else
                        continue;
            }

            return bet;

        }
    }
}
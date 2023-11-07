using GeradorDeApostas.Models;
using GeradorDeApostas.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeradorDeApostas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenerateBetController : ControllerBase
    {
        private readonly IBetRepository _betRepository;
        public GenerateBetController(IBetRepository betRepository)
        {
            _betRepository = betRepository;
        }

        [HttpGet]
        public IEnumerable<Bet> GetBets()
        {
            var bets = _betRepository.GetBets();

            return bets;
        }

        [HttpGet("Id")]
        public Bet GetBetsById(int id)
        {
            var bet = _betRepository.GetBetsById(id);
            

            return bet;
        }

        [HttpPost]
        public Bet PostBets(int numberGames, int qtGames)
        {
            var bet = new Bet()
            {
                numberGames = numberGames,
                qtGames = qtGames,
                resultGames = "1,2,3,4,5"
            };

            _betRepository.PostBets(bet);
            _betRepository.Save();

            return bet;

        }
    }
}

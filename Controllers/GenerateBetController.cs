using GeradorDeApostas.Models;
using GeradorDeApostas.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GeradorDeApostas.Controllers
{
    [ApiController]
    public class GenerateBetController : ControllerBase
    {
        private readonly IBetRepository _betRepository;
        public GenerateBetController(IBetRepository betRepository)
        {
            _betRepository = betRepository;
        }

        [HttpGet("v1/bets")]
        public IEnumerable<Bet> GetBets()
        {
            var bets = _betRepository.GetBets();

            return bets;
        }

        [HttpGet("v1/bets/{id}")]
        public Bet GetBetsById([FromRoute] int id)
        {
            var bet = _betRepository.GetBetsById(id);


            return bet;
        }

        [HttpPost("v1/bets")]
        public Bet PostBets(int totalNumber)
        {

            // Gerar aposta com quantidade de numeros que deseja minimo 6 e máximo 15
            var bet = _betRepository.GenerateBet(totalNumber);

            if (!bet.error)
            {
                _betRepository.PostBets(bet);
                _betRepository.Save();
            }

            return bet;

        }
    }
}

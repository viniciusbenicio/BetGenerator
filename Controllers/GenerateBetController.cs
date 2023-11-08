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

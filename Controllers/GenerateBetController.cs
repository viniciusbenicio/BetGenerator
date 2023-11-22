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
        public IActionResult GetAsync()
        {
            var bets = _betRepository.GetBets();

            return Ok(bets);
        }

        [HttpGet("v1/bets/{id}")]
        public async Task<IActionResult> GetBetsByIdAsync([FromRoute] int id)
        {
            var bet = await _betRepository.GetBetsByIdAsync(id);

            return Ok(bet);
        }

        [HttpPost("v1/bets")]
        public async Task<IActionResult> PostBetsAsync(int totalNumber)
        {
            // Gerar aposta com quantidade de numeros que deseja minimo 6 e máximo 15
            var bet = _betRepository.GenerateBet(totalNumber);

            if (!bet.Error)
            {
                await _betRepository.PostBetsAsync(bet);
                await _betRepository.SaveAsync();
            }

            return Ok(bet);

        }
    }
}

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

        /// <summary>
        /// Listar todas apostas criadas na API.
        /// </summary>
        /// <returns></returns>
        [HttpGet("v1/bets")]
        public IActionResult GetAsync()
        {
            var bets = _betRepository.GetBets();

            return Ok(bets);
        }

        /// <summary>
        /// Listar aposta pelo ID na API.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("v1/bets/{id}")]
        public async Task<IActionResult> GetBetsByIdAsync([FromRoute] int id)
        {
            var bet = await _betRepository.GetBetsByIdAsync(id);

            return Ok(bet);
        }

        /// <summary>
        /// Criar aposta na API.
        /// </summary>
        /// <param name="totalNumber"></param>
        /// <param name="numberOfGames"></param>
        /// <returns></returns>
        [HttpPost("v1/bets")]
        public async Task<IActionResult> PostBetsAsync(int totalNumber, int? numberOfGames)
        {
            // Gerar aposta com quantidade de numeros que deseja minimo 6 e máximo 15 
            var bet = await _betRepository.GenerateBetAsync(totalNumber, numberOfGames);

            if(bet != null) 
                return Ok(bet);
            else 
                return BadRequest();

        }
    }
}

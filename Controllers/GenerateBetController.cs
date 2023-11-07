using GeradorDeApostas.Data.Mappings;
using GeradorDeApostas.Models;
using Microsoft.AspNetCore.Mvc;

namespace GeradorDeApostas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenerateBetController : ControllerBase
    {
        [HttpGet] 
        public IActionResult Get([FromBody] Bet bet)
        {
            return null;
        }

        [HttpPost]
        public void PostBets([FromBody] Bet bet, [FromServices] ApostasDBContext context)
        {
            bet = new Bet()
            {
                numberGames = 1,
                qtGames = 1,
                resultGames = "1,2,3,4,5"
            };


            context.bets.Add(bet);
            context.SaveChanges();

        }
    }
}

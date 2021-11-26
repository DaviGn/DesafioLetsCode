using Domain.Commands.Rebel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DesafioLetsCode.Controllers
{
    /// <summary>
    /// Controller responsável por reportar um Rebelde como traidor
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RebelBetrayalReport : ControllerBase
    {
        private readonly IMediator _mediator;

        public RebelBetrayalReport(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Reporta um Rebelde como traidor
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(ReportBetrayalRebelCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}

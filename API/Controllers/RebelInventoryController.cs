using Domain.Commands.RebelInventory;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DesafioLetsCode.Controllers
{
    /// <summary>
    /// Controller responsável por negociar items entre Rebeldes
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RebelInventoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RebelInventoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Negocia items entre dois Rebeldes
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(RebelInventoryExchangeCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}

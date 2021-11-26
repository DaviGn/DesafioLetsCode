using Domain.Commands.Rebel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DesafioLetsCode.Controllers
{
    /// <summary>
    /// Controller responsável por manipular a entidade Rebelde
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RebelController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RebelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Cadastra um Rebelde
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(CreateRebelCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Atualiza a localização de um Rebelde
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put(UpdateRebelCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}

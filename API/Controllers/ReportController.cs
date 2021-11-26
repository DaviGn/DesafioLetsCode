using Domain.Queries.Report;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DesafioLetsCode.Controllers
{
    /// <summary>
    /// Controller responsável por fornecer relatórios
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReportController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retorna o relatório de porcentagem de traidores
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/traitorPercentage")]
        public async Task<IActionResult> TraitorPercentage()
        {
            var query = new TraitorPercentageQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        /// <summary>
        /// Retorna o relatório de quantidade de rebeldes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/rebelsCount")]
        public async Task<IActionResult> RebelsCount()
        {
            var query = new RebelCountQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        /// <summary>
        /// Retorna o relatório de quantidade média de cada item de inventário por rebelde
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/inventoryItemsAverage")]
        public async Task<IActionResult> InventoryItemsAverage()
        {
            var query = new InventoryItemAverageQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        /// <summary>
        /// Retorna o relatório de pontos perdidos por traidores
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/lostPoints")]
        public async Task<IActionResult> LostPoints()
        {
            var query = new LostPointsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}

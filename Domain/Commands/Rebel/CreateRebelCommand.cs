using Domain.Enums;
using MediatR;
using System.Collections.Generic;

namespace Domain.Commands.Rebel
{
    public class RebelInventoryDTO
    {
        /// <summary>
        /// Id do item
        /// </summary>
        public int ItemId { get; set; }
        /// <summary>
        /// Quantidade em posse
        /// </summary>
        public int Count { get; set; }
    }

    public class CreateRebelCommand : IRequest
    {
        public CreateRebelCommand()
        {
            InventoryItems = new List<RebelInventoryDTO>();
        }

        /// <summary>
        /// Nome do rebelde
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Idade do rebelde
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// Gênero do rebelde
        /// </summary>
        public Gender? Gender { get; set; }
        /// <summary>
        /// Latitude
        /// </summary>
        public decimal Latitude { get; set; }
        /// <summary>
        /// Longitude
        /// </summary>
        public decimal Longitude { get; set; }
        /// <summary>
        /// Nome da galáxia
        /// </summary>
        public string GalaxyName { get; set; }

        /// <summary>
        /// Items do inventário
        /// </summary>
        public IEnumerable<RebelInventoryDTO> InventoryItems { get; set; }
    }
}

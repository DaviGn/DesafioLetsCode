using MediatR;
using System.Collections.Generic;

namespace Domain.Commands.RebelInventory
{
    public class ItemDTO
    {
        public int ItemId { get; set; }
        public int Count { get; set; }
    }

    public class RebelInventoryExchangeCommand : IRequest
    {
        public int FirstRebelId { get; set; }
        public IEnumerable<ItemDTO> FirstRebelItems { get; set; }
        public int SecondRebelId { get; set; }
        public IEnumerable<ItemDTO> SecondRebelItems { get; set; }
    }
}

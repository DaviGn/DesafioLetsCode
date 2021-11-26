using DB;
using Domain.Commands.RebelInventory;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Handlers.Commands.RebelInventory
{
    public class RebelInventoryExchangeCommandHandler : AsyncRequestHandler<RebelInventoryExchangeCommand>
    {
        private readonly Context _context;

        public RebelInventoryExchangeCommandHandler(Context context)
        {
            _context = context;
        }

        protected override async Task Handle(RebelInventoryExchangeCommand request, CancellationToken cancellationToken)
        {
            var firstRebel = await _context.Rebel.FirstOrDefaultAsync(x => x.Id == request.FirstRebelId);
            var secondRebel = await _context.Rebel.FirstOrDefaultAsync(x => x.Id == request.SecondRebelId);

            if (firstRebel.Traitor || secondRebel.Traitor)
                throw new ValidationException("Traidores não podem negociar items!");

            var firstItemsIds = request.FirstRebelItems.Select(x => x.ItemId);
            var secondItemsIds = request.SecondRebelItems.Select(x => x.ItemId);

            var firstItems = await _context.InventoryItem.Where(x => firstItemsIds.Contains(x.Id))
                                           .AsNoTracking().ToListAsync();

            var secondItems = await _context.InventoryItem.Where(x => secondItemsIds.Contains(x.Id))
                                           .AsNoTracking().ToListAsync();

            int firstPoints = 0;
            int secondPoints = 0;

            foreach (var item in firstItems)
            {
                var aux = request.FirstRebelItems.FirstOrDefault(x => x.ItemId == item.Id);
                firstPoints += aux.Count * item.Points;
            }

            foreach (var item in secondItems)
            {
                var aux = request.SecondRebelItems.FirstOrDefault(x => x.ItemId == item.Id);
                secondPoints += aux.Count * item.Points;
            }

            if (firstPoints != secondPoints)
                throw new ValidationException("A quantidade de pontos deve ser igual!");

            foreach (var item in request.FirstRebelItems)
            {
                await Exchange(request.FirstRebelId, request.SecondRebelId, item);
            }
            foreach (var item in request.SecondRebelItems)
            {
                await Exchange(request.SecondRebelId, request.FirstRebelId, item);
            }

            await _context.SaveChangesAsync();
        }

        private async Task Exchange(int leftRebelId, int rightRebelId, ItemDTO item)
        {
            var itemFirstRebel = await _context.RebelInventory.FirstOrDefaultAsync(x => x.RebelId == rightRebelId && x.ItemId == item.ItemId);

            if (itemFirstRebel is not null)
            {
                itemFirstRebel.Count += item.Count;
                _context.RebelInventory.Attach(itemFirstRebel).State = EntityState.Modified;
            }
            else
            {
                itemFirstRebel = new()
                {
                    ItemId = item.ItemId,
                    RebelId = rightRebelId,
                    Count = item.Count
                };
                await _context.RebelInventory.AddAsync(itemFirstRebel);
            }

            var itemSecondRebel = await _context.RebelInventory.FirstOrDefaultAsync(x => x.RebelId == leftRebelId && x.ItemId == item.ItemId);

            if (itemFirstRebel.Count - item.Count <= 0)
                _context.RebelInventory.Remove(itemSecondRebel);
            else
            {
                itemFirstRebel.Count -= item.Count;
                _context.RebelInventory.Attach(itemSecondRebel).State = EntityState.Modified;
            }
        }
    }
}

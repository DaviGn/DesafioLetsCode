using DB;
using Domain.Queries.Report;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Handlers.Queries.Report
{
    public class InventoryItemAverageQueryHandler : IRequestHandler<InventoryItemAverageQuery, object>
    {
        private readonly Context _context;

        public InventoryItemAverageQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<object> Handle(InventoryItemAverageQuery request, CancellationToken cancellationToken)
        {
            var items = await _context.InventoryItem.Include(i => i.RebelIventories).AsNoTracking().ToListAsync();

            return items.Select(x => new
            {
                itemId = x.Id,
                name = x.Name,
                average = x.RebelIventories.Any() ? x.RebelIventories.Sum(s => s.Count) / x.RebelIventories.Count : 0
            });
        }
    }
}

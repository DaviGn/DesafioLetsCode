using DB;
using Domain.Queries.Report;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Handlers.Queries.Report
{
    public class LostPointsQueryHandler : IRequestHandler<LostPointsQuery, object>
    {
        private readonly Context _context;

        public LostPointsQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<object> Handle(LostPointsQuery request, CancellationToken cancellationToken)
        {
            var traitors = await _context.Rebel.Where(x => x.ReportCount >= 3)
                                         .Include(i => i.RebelInventory).ThenInclude(t => t.Item)
                                         .AsNoTracking().ToListAsync();

            return new
            {
                totalPoints = traitors.Sum(x => x.RebelInventory.Sum(s => s.Count * s.Item.Points))
            };
        }
    }
}

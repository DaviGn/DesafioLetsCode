using DB;
using Domain.Queries.Report;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Handlers.Queries.Report
{
    public class TraitorPercentageQueryHandler : IRequestHandler<TraitorPercentageQuery, object>
    {
        private readonly Context _context;

        public TraitorPercentageQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<object> Handle(TraitorPercentageQuery request, CancellationToken cancellationToken)
        {
            var rebelds = await _context.Rebel.ToListAsync();

            return new
            {
                traitorPercentage = !rebelds.Any() ? 0 : (rebelds.Count(x => x.Traitor) / rebelds.Count) * 100
            };
        }
    }
}

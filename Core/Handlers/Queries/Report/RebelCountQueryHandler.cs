using DB;
using Domain.Queries.Report;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Handlers.Queries.Report
{
    public class RebelCountQueryHandler : IRequestHandler<RebelCountQuery, object>
    {
        private readonly Context _context;

        public RebelCountQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<object> Handle(RebelCountQuery request, CancellationToken cancellationToken)
        {
            var count = await _context.Rebel.CountAsync();

            return new
            {
                rebelsCount = count
            };
        }
    }
}

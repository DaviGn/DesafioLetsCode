using DB;
using Domain.Commands.Rebel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Handlers.Commands.Rebel
{
    public class ReportBetrayalRebelCommandHandler : AsyncRequestHandler<ReportBetrayalRebelCommand>
    {
        private readonly Context _context;

        public ReportBetrayalRebelCommandHandler(Context context)
        {
            _context = context;
        }

        protected override async Task Handle(ReportBetrayalRebelCommand request, CancellationToken cancellationToken)
        {
            var model = await _context.Rebel.FirstOrDefaultAsync(x => x.Id == request.RebelId);
            model.ReportCount++;

            _context.Rebel.Attach(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

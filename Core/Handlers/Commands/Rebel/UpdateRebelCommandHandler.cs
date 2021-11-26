using DB;
using Domain.Commands.Rebel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Handlers.Commands.Rebel
{
    public class UpdateRebelCommandHandler : IRequestHandler<UpdateRebelCommand>
    {
        private readonly Context _context;

        public UpdateRebelCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateRebelCommand request, CancellationToken cancellationToken)
        {
            var model = await _context.Rebel.FirstOrDefaultAsync(x => x.Id == request.Id);
            model.Latitude = request.Latitude;
            model.Longitude = request.Longitude;
            model.GalaxyName = request.GalaxyName;

            _context.Rebel.Attach(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return await Unit.Task;
        }
    }
}

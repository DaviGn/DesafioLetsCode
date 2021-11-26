using AutoMapper;
using DB;
using Domain.Commands.Rebel;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Handlers.Commands.Rebel
{
    public class CreateRebelCommandHandler : IRequestHandler<CreateRebelCommand>
    {
        private readonly IMapper _mapper;
        private readonly Context _context;

        public CreateRebelCommandHandler(Context context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Unit> Handle(CreateRebelCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Domain.Models.Rebel>(request);
            await _context.Rebel.AddAsync(model);

            foreach (var item in request.InventoryItems)
            {
                await _context.RebelInventory.AddAsync(new()
                {
                    Rebel = model,
                    ItemId = item.ItemId,
                    Count = item.Count
                });
            }

            await _context.SaveChangesAsync();
            return await Unit.Task;
        }
    }
}

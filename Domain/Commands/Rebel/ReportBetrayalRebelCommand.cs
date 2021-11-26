using MediatR;

namespace Domain.Commands.Rebel
{
    public class ReportBetrayalRebelCommand : IRequest
    {
        public int RebelId { get; set; }
    }
}

using MediatR;

namespace Domain.Commands.Rebel
{
    public class UpdateRebelCommand : IRequest
    {
        public int Id { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string GalaxyName { get; set; }
    }
}

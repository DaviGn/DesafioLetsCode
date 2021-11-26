using AutoMapper;
using Domain.Commands.Rebel;
using Domain.Models;

namespace Core.MapperTool
{
    public static class AutoMapperConfiguration
    {
        public static IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreateRebelCommand, Rebel>();
            });

            return config.CreateMapper();
        }
    }
}

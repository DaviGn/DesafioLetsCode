using AutoMapper;
using Core.Handlers.Commands.Rebel;
using Core.MapperTool;
using DB;
using Domain.Commands.Rebel;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class RebelTests
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public RebelTests()
        {
            var options = new DbContextOptionsBuilder<Context>()
                           .UseInMemoryDatabase(databaseName: "DesafioLetsCode")
                           .Options;

            context = new Context(options);
            mapper = AutoMapperConfiguration.Configure();
        }

        [TestMethod]
        public async Task Create_New_Rebel()
        {
            //Arange
            CreateRebelCommandHandler handler = new CreateRebelCommandHandler(context, mapper);
            CreateRebelCommand command = new CreateRebelCommand();
            command.Name = "Davi";
            command.Age = 24;
            command.Gender = Domain.Enums.Gender.Male;
            command.Latitude = -23.6231455m;
            command.Longitude = -46.534233m;
            command.GalaxyName = "Toquio";
            command.InventoryItems = new List<RebelInventoryDTO> {
                new RebelInventoryDTO(){ ItemId = 1, Count = 1 }
            };

            //Act
            await handler.Handle(command, default);

            //Assert
            Assert.AreEqual(1, context.Rebel.Count());
        }

        [TestMethod]
        public async Task Update_Rebel()
        {
            //Arange
            var oldRebel = await context.Rebel.Where(x => x.Id == 1).AsNoTracking().FirstOrDefaultAsync();

            UpdateRebelCommandHandler handler = new UpdateRebelCommandHandler(context);
            UpdateRebelCommand command = new UpdateRebelCommand();
            command.Id = 1;
            command.Latitude = -23.7089881m;
            command.Longitude = -46.553267m;
            command.GalaxyName = "Marechal";

            //Act
            await handler.Handle(command, default);

            //Assert
            var currentRebel = await context.Rebel.Where(x => x.Id == 1).AsNoTracking().FirstOrDefaultAsync();
            Assert.IsTrue(oldRebel.Latitude != currentRebel.Latitude && oldRebel.Longitude != currentRebel.Longitude);
        }
    }
}

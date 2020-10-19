using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HPlusSports.DAL;
using Microsoft.EntityFrameworkCore;
using HPlusSports.Models;
using System.Threading.Tasks;
using Moq;
using HPlusSports.Core.Test.Mocks;
using Microsoft.Extensions.DependencyInjection;

namespace HPlusSports.Core.Test
{
    [TestClass]
    public class SalesPersonServiceTests
    {
        ServiceProvider serviceProvider;

        public SalesPersonServiceTests(){
            var services = new ServiceCollection();
            services.AddScoped<ISalesPersonRepository, SalesPersonRepositoryMock>();
            services.AddScoped<ITrackingRepository<SalesGroup>, SalesGroupRepositoryMock>();
            services.AddTransient<ISalesPersonService, SalesPersonService>();
            serviceProvider = services.BuildServiceProvider();
        }

        [TestMethod]
        public async Task MoveSalesPersonWithoutGroupToExistingGroup()
        {
            var salesRepo = serviceProvider.GetService<ISalesPersonRepository>();
            var salesGroupRepo = serviceProvider.GetService<ITrackingRepository<SalesGroup>>();

            salesGroupRepo.Add(new SalesGroup() { State = "TEST", Type = 1, Id = 1 });
            salesRepo.Add(new Salesperson() { Id = 1 });

            var service = serviceProvider.GetService<ISalesPersonService>();

            await service.MoveSalesPersonToGroup(1, 1);

            var person = await salesRepo.GetByID(1);

            Assert.IsTrue(person.SalesGroup.State == "TEST");
        }

        [TestMethod]
        public async Task MoveSalesPersonWithoutGroupToExistingGroupMoq()
        {
            var srMock = new Mock<ISalesPersonRepository>();
            var sgrMock = new Mock<ITrackingRepository<SalesGroup>>();

            var salesperson = new Salesperson() { Id = 1 };
            sgrMock.Setup(x => x.GetByID(1)).Returns(Task.FromResult(new SalesGroup() { Id = 1, State = "TEST" }));

            srMock.Setup(x => x.GetByID(1)).Returns(Task.FromResult(salesperson));

            srMock.Setup(x => x.Save(It.IsAny<Salesperson>())).Callback<Salesperson>(p => salesperson = p);

            var service = new SalesPersonService(srMock.Object, sgrMock.Object);

            await service.MoveSalesPersonToGroup(1, 1);

            var person = await srMock.Object.GetByID(1);

            Assert.IsTrue(person.SalesGroup.State == "TEST");
        }
    }
}

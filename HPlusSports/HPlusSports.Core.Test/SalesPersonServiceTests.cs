using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HPlusSports.DAL;
using Microsoft.EntityFrameworkCore;
using HPlusSports.Models;
using System.Threading.Tasks;
using Moq;
using HPlusSports.Core.Test.Mocks;

namespace HPlusSports.Core.Test
{
    [TestClass]
    public class SalesPersonServiceTests
    {
        [TestMethod]
        public async Task MoveSalesPersonWithoutGroupToExistingGroup()
        {
            var salesRepo = new SalesPersonRepositoryMock();
            var salesGroupRepo = new SalesGroupRepositoryMock();

            salesGroupRepo.Add(new SalesGroup() { State = "TEST", Type = 1, Id = 1 });
            salesRepo.Add(new Salesperson() { Id = 1 });

            var service = new SalesPersonService(salesRepo, salesGroupRepo);

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

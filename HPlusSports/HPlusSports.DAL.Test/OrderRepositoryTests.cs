using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using HPlusSports.Models;

namespace HPlusSports.DAL.Test
{
    [TestClass]
    public class OrderRepositoryTests
    {
        [TestMethod]
        public async Task PartialLastNameIsCaseInsensitive()
        {
            using (var context = Helpers.GetContext("LastNameCaseTest"))
            {
                context.AddRange(new Order[] 
                {
                    new Order(){ Customer = new Customer (){ LastName = "Smithy" } },
                    new Order(){ Customer = new Customer (){ LastName = "Smithers" } },
                    new Order(){ Customer = new Customer (){ LastName = "Smithson" } },
                    new Order(){ Customer = new Customer (){ LastName = "McSmith" } },
                    new Order(){ Customer = new Customer (){ LastName = "SMITH" } },
                    new Order(){ Customer = new Customer (){ LastName = "smi" } },
                });
                await context.SaveChangesAsync();
            }

            using (var context = Helpers.GetContext("LastNameCaseTest"))
            {
                var repo = new OrderRepository(context);

                Assert.AreEqual(6, (await repo.GetByCustomerPartialLastName("smi")).Count);
                Assert.AreEqual(5, (await repo.GetByCustomerPartialLastName("smith")).Count);
                Assert.AreEqual(1, (await repo.GetByCustomerPartialLastName("MC")).Count);

            }


        }

    }
}

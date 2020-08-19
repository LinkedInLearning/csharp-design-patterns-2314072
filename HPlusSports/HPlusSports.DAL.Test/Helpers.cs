using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HPlusSports.DAL.Test
{
    public static class Helpers
    {
        public static HPlusSportsContext GetContext(string name)
        {
            var dbOptions = new DbContextOptionsBuilder<HPlusSportsContext>()
                .UseInMemoryDatabase(name).Options;
            return new HPlusSportsContext(dbOptions);
        }
    }
}

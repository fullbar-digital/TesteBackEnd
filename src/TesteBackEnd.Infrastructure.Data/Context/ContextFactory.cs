using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TesteBackEnd.Infrastructure.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<TesteBackEndDbContext>
    {
        public TesteBackEndDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TesteBackEndDbContext>();
            optionsBuilder.UseSqlServer("Persist Security Info=False;User ID=sa; Password=L30&t4t4; Initial Catalog=TesteBackEnd;Data Source=localhost;");

            return new TesteBackEndDbContext(optionsBuilder.Options);

        }
    }
}

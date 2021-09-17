using api_restful.Controllers.Model;
using Microsoft.EntityFrameworkCore;

namespace api_restful.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() {}

        public MySQLContext(
            DbContextOptions<MySQLContext> options)
            : base(options)
        {
        }

        public DbSet<Person> persons { get; set; }
    }
}

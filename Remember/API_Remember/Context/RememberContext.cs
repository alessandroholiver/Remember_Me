using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Remember.Models
{
    public class RememberContext: DbContext
    {

        public RememberContext()
        {

        }

        public RememberContext(DbContextOptions<RememberContext> opcoes)
            : base(opcoes)
        { }

        public DbSet<User> Users { get; set; }

       
    }
}

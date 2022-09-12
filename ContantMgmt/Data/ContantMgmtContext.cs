using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ContantMgmt.Models;

namespace ContantMgmt.Data
{
    public class ContantMgmtContext : DbContext
    {
        public ContantMgmtContext (DbContextOptions<ContantMgmtContext> options)
            : base(options)
        {
        }

        public DbSet<ContantMgmt.Models.Contact> Contact { get; set; } = default!;
    }
}

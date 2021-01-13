using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PIN_Lab06.Models;

namespace PIN_Lab06.Data
{
    public class PticeContext : DbContext
    {
        public PticeContext (DbContextOptions<PticeContext> options)
            : base(options)
        {
        }

        public DbSet<PIN_Lab06.Models.Ptice> Ptice { get; set; }
    }
}

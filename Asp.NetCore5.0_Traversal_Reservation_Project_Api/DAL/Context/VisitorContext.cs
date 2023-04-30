using Asp.NetCore5._0_Traversal_Reservation_Project_Api.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore5._0_Traversal_Reservation_Project_Api.DAL.Context
{
    public class VisitorContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;initial catalog=TraversalDBApi;integrated security=true;");
        }
        public DbSet<Visitor> Visitors{ get; set; }
    }
}

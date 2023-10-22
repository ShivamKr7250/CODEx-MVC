using CODEx.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODEx.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Events> Event { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Events>().HasData(
                new Events { Id=1, Name="Da-Vinci Code 3.0", Description="This was a Technical Event", TotalParticipant=70 },
                new Events { Id = 2, Name = "X-QuizIT 3.0", Description = "This was a Technical Event", TotalParticipant = 90 },
                new Events { Id = 3, Name = "Edge Map ", Description = "This was a Technical Event", TotalParticipant = 60 },
                new Events { Id = 4, Name = "TechNode", Description = "This was a Technical Event", TotalParticipant = 120 }
                );
        }
    }
}
 
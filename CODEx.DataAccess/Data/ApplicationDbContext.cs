using CODEx.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CODEx.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Events> Event { get; set; }

        public DbSet<Coordinator> Coordinator { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<RegistrationForm> RegistrationForm { get; set; }

        public DbSet<Faculty> Faculties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Events>().HasData(
                new Events { Id=1, Name="Da-Vinci Code 3.0", Description="This was a Technical Event", TotalParticipant=70 },
                new Events { Id = 2, Name = "X-QuizIT 3.0", Description = "This was a Technical Event", TotalParticipant = 90 },
                new Events { Id = 3, Name = "Edge Map ", Description = "This was a Technical Event", TotalParticipant = 60 },
                new Events { Id = 4, Name = "TechNode", Description = "This was a Technical Event", TotalParticipant = 120 }
                );

            modelBuilder.Entity<Coordinator>().HasData(
                new Coordinator { Id = 1, Name = "Da-Vinci Code 3.0", Description = "This was a Technical Event", Designation= "President" , Batch="2021-2025"},
                new Coordinator { Id = 2, Name = "X-QuizIT 3.0", Description = "This was a Technical Event", Designation = "Vice-President" , Batch = "2021-2025" },
                new Coordinator { Id = 3, Name = "Edge Map ", Description = "This was a Technical Event", Designation = "Secretary", Batch = "2021-2025" },
                new Coordinator { Id = 4, Name = "TechNode", Description = "This was a Technical Event", Designation = "Vice-Secretary", Batch = "2021-2025" }
                );

            modelBuilder.Entity<Faculty>().HasData(
                new Faculty { Id=1, Name="S.P Singh", Desigation="Faculty Coordinator", ImageUrl="" },
                new Faculty { Id = 2, Name = "Vineta Gulati", Desigation = "Faculty Coordinator", ImageUrl = "" });
        }
    }
}
 
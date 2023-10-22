using Microsoft.EntityFrameworkCore;
using MyFitness.BL.Model;

namespace MyFitness.BL.Controller {
	public class FitnessContext : DbContext {
		public FitnessContext() => Database.EnsureCreated();

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=fitness;Trusted_Connection=True;");
		}

		public DbSet<Activity> Activities { get; set; }
		public DbSet<Eating> Eatings { get; set; }
		public DbSet<Exercise> Exercises { get; set; }
		public DbSet<Food> Foods { get; set; }
		public DbSet<Gender> Genders { get; set; }
		public DbSet<User> Users { get; set; }
	}
}

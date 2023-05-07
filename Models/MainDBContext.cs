using Microsoft.EntityFrameworkCore;

namespace WebApplication_Core_Day09.Models
{
	public class MainDBContext : DbContext
	{
		public MainDBContext(DbContextOptions<MainDBContext> options) : base(options) { }
		
		public DbSet<Trainee> Trainees { get; set; }
		public DbSet<Track> Tracks { get; set; }
		public DbSet<Course> Courses { get; set; }
	}
}

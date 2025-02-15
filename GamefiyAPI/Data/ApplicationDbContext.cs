using GamefiyAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GamefiyAPI.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}
		public DbSet<Game> Games { get; set; }
		public DbSet<Publisher> Publisher { get; set; }
	}
}

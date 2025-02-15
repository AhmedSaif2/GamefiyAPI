using GamefiyAPI.Data;
using GamefiyAPI.Models;
using GamefiyAPI.Repositories.Interfaces;

namespace GamefiyAPI.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		ApplicationDbContext _context;
		public IRepository<Game> Games { get; private set; }
		public IRepository<Publisher> Publishers { get;private set; }
		public IRepository<User> Users { get; private set; }
		public IRepository<Review> Reviews { get; private set; }

		public UnitOfWork(ApplicationDbContext context, IRepository<Game> games, IRepository<Publisher> publishers,IRepository<User>users,IRepository<Review>reviews)
		{
			_context = context;
			Games = games; 
			Publishers = publishers;
			Users = users;
			Reviews = reviews;
		}
		public void Save()
		{
			_context.SaveChanges();
		}
		public void Dispose()
		{
			_context.Dispose();
		}

	}
}

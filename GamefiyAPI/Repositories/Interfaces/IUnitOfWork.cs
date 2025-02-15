using GamefiyAPI.Models;

namespace GamefiyAPI.Repositories.Interfaces
{
	public interface IUnitOfWork : IDisposable
	{
		IRepository<Game> Games { get; }
		IRepository<Publisher> Publishers { get; }
		IRepository<User> Users { get; }
		IRepository<Review> Reviews { get; }
		void Save();
	}
}

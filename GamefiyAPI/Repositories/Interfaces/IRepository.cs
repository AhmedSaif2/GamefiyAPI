using System.Linq.Expressions;

namespace GamefiyAPI.Repositories.Interfaces
{
	public interface IRepository<T> where T : class
	{
		T Get(string id);
		T Get(Expression<Func<T, bool>> predicate, string[] include);
		List<T> Search(Expression<Func<T, bool>> predicate, string[] include);
		List<T> GetAll(int pageNumber, int pageSize);
		List<T> GetAll(string[] include, int pageNumber,int pageSize);
		void Add(T entity);
		void Update(T entity);
		void Delete(T entity);
	}
}

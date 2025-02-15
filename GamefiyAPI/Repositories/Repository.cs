using GamefiyAPI.Data;
using GamefiyAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Linq.Expressions;

namespace GamefiyAPI.Repositories
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly ApplicationDbContext _context;
		public Repository(ApplicationDbContext context)
		{
			_context = context;
		}
		public T Get(Expression<Func<T, bool>> predicate,string[] include)
		{
			IQueryable<T> query = _context.Set<T>();

			if (include != null)
			{
				foreach (var item in include)
				{
					query = query.Include(item);
				}
			}
			return query.FirstOrDefault(predicate);
		}
		public List<T> GetAll(int pageNumber, int pageSize)
		{
			return _context.Set<T>().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
		}
		public List<T> GetAll(string[] include,int pageNumber=1,int pageSize=10)
		{
			IQueryable<T> query = _context.Set<T>();

			if (include != null)
			{
				foreach (var item in include)
				{
					query = query.Include(item);
				}
			}
			query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
			return query.ToList();
		}
		public void Add(T entity)
		{
			_context.Set<T>().Add(entity);
		}

		public void Delete(T entity)
		{
			_context.Set<T>().Remove(entity);
		}
		public void Update(T entity)
		{
			_context.Set<T>().Update(entity);
		}

		public T Get(string id)
		{
			return _context.Set<T>().Find(id);
		}

		public List<T> Search(Expression<Func<T, bool>> predicate, string[]include)
		{
			var query = _context.Set<T>().AsQueryable();
			if (include != null)
			{
				foreach (var item in include)
				{
					query = query.Include(item);
				}
			}
			return query.Where(predicate).ToList();
		}
	}
}

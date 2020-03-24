using System;
using Entities.DataContext;

namespace DataAccess.Generic
{
    public interface IUnitOfWork: IDisposable
    {
        ApplicationDbContext Context { get; }
        void Commit();
    }

    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext Context { get; }

        public UnitOfWork(ApplicationDbContext _context)
        {
            Context = _context;
        }

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}

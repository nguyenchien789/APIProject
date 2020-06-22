using DAL.Repositories;
using System;

namespace DAL.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryBase<T> GetRepository<T>() where T : class;

        void Commit();
    }
}

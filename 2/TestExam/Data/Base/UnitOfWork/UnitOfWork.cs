using Data.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace Data.Base.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public TestContext Context { get; }
        private IDbContextTransaction _transaction;


        public UnitOfWork(TestContext context)
        {
            Context = context;
        }

        public void Dispose()
        {
            Context?.Dispose();
            _transaction?.Dispose();
        }

        public void BeginTransaction()
        {
            _transaction = Context.Database.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                _transaction?.Commit();
            }
            catch
            {
                _transaction?.Rollback();

                throw;
            }
            finally
            {
                _transaction?.Dispose();
            }
        }

        public void Rollback()
        {
            try
            {
                _transaction?.Rollback();
            }
            finally
            {
                _transaction?.Dispose();
            }
        }
    }
}
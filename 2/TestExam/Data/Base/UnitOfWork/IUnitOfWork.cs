using Data.Context;

namespace Data.Base.UnitOfWork
{
    public interface IUnitOfWork
    {
        TestContext Context { get; }

        void BeginTransaction();

        void Commit();

        void Rollback();
    }
}
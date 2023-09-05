using SWQT._224DataAccessSQLiteEFCore.Repository;
using SWQT._576Entity.Entities;

namespace SWQT._224DataAccessSQLiteEFCore
{
    public interface IUnitOfWork : IDisposable
    {
        GenericRepository<TblListPost> PostRepository();
        void Save();
        //void Dispose();
    }
}

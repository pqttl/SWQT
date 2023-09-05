using SWQT._512ViewModels.Admin.Post;
using SWQT._576Entity.Entities;

namespace SWQT._224DataAccessSQLiteEFCore.Repository
{
    public interface IPostRepository : IDisposable
    {
        IEnumerable<TblListPost> GetAllList();
        TblListPost GetByID(int id);
        void Insert(TblListPost mInput);
        void DeleteById(int intId);
        void Update(TblListPost mInput);
        List<TblListPost> LstByPageAndSize(VMGetPostPaging mRequest);

        int IntTotalRow();
    }
}

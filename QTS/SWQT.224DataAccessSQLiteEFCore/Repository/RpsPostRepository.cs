using Microsoft.EntityFrameworkCore;
using SWQT._224DataAccessSQLiteEFCore.EFCore;
using SWQT._512ViewModels.Admin.Post;
using SWQT._576Entity.Entities;

namespace SWQT._224DataAccessSQLiteEFCore.Repository
{
    public class RpsPostRepository : IPostRepository, IDisposable
    {
        // SWQTDbContext kế thừa từ DbContext, và có thêm DbSet<Student>
        private SWQTDbContext context;

        public RpsPostRepository(SWQTDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<TblListPost> GetAllList()
        {
            return context.TblListPost!.ToList();
        }

        public TblListPost GetByID(int id)
        {
            return context.TblListPost!.Find(id)!;
        }

        public void Insert(TblListPost mInput)
        {
            context.TblListPost!.Add(mInput);
        }

        public void DeleteById(int intId)
        {
            TblListPost mTemp = context.TblListPost!.Find(intId)!;
            context.TblListPost.Remove(mTemp);
        }

        public void Update(TblListPost mInput)
        {
            context.Entry(mInput).State = EntityState.Modified;
        }

        public List<TblListPost> LstByPageAndSize(VMGetPostPaging mRequest)
        {
            return context.TblListPost!
                    .OrderByDescending(x => x.Id)
        .Skip((mRequest.IntPageIndex - 0) * mRequest.IntPageSize).Take(mRequest.IntPageSize).ToList();
        }

        public int IntTotalRow()
        {
            return context.TblListPost!.Count();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

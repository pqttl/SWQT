using SWQT._224DataAccessSQLiteEFCore.EFCore;
using SWQT._224DataAccessSQLiteEFCore.Repository;
using SWQT._576Entity.Entities;

namespace SWQT._224DataAccessSQLiteEFCore
{
    public class UnitOfWork : IUnitOfWork
    {
        private SWQTDbContext context = new SWQTDbContext();
        private GenericRepository<TblListPost>? postRepository;
        //private GenericRepository<Course> courseRepository;

        // Kiểm tra xem repository đã được khởi tạo chưa
        //public GenericRepository<TblListPost> PostRepository
        //{
        //    get
        //    {
        //        if (this.postRepository == null)
        //        {
        //            this.postRepository = new GenericRepository<TblListPost>(context);
        //        }
        //        return postRepository;
        //    }
        //}
        // Kiểm tra xem repository đã được khởi tạo chưa
        public GenericRepository<TblListPost> PostRepository()
        {
            if (this.postRepository == null)
            {
                this.postRepository = new GenericRepository<TblListPost>(context);
            }
            return postRepository;
        }

        // Kiểm tra xem repository đã được khởi tạo chưa
        //public GenericRepository<Course> CourseRepository
        //{
        //    get
        //    {
        //        if (this.courseRepository == null)
        //        {
        //            this.courseRepository = new GenericRepository<Course>(context);
        //        }
        //        return courseRepository;
        //    }
        //}

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

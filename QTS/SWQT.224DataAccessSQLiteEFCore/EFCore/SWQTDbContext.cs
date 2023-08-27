using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SWQT._576Entity.Entities;

namespace SWQT._224DataAccessSQLiteEFCore.EFCore
{
    internal class SWQTDbContext:DbContext
    {

        #region Danh sach Dbset

        public DbSet<BangAccount>? BangAccount { get; set; }
        
        public DbSet<BangChiTietDonHang>? BangChiTietDonHang { get; set; }
        
        public DbSet<BangChiTietTienNo>? BangChiTietTienNo { get; set; }
        
        public DbSet<BangDanhSachDonHang>? BangDanhSachDonHang { get; set; }
        
        public DbSet<BangGiaHan>? BangGiaHan { get; set; }
        
        public DbSet<BangGiaViThuoc>? BangGiaViThuoc { get; set; }
        
        public DbSet<BangKhachHang>? BangKhachHang { get; set; }
        
        public DbSet<BangViThuoc>? BangViThuoc { get; set; }
        
        public DbSet<TblHistoryInDepot>? TblHistoryInDepot { get; set; }
        
        public DbSet<TblJson>? TblJson { get; set; }
        
        public DbSet<TblJsonPrintOrder>? TblJsonPrintOrder { get; set; }
        
        public DbSet<TblListNameCustomer>? TblListNameCustomer { get; set; }
        
        public DbSet<TblListPost>? TblListPost { get; set; }
        
        public DbSet<TblListProductInDepot>? TblListProductInDepot { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string StrConnectionString = configuration.GetSection("ConnectionStrings")["DNQTSolutionDb"];
            optionsBuilder.UseSqlite(StrConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BangAccount>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<BangChiTietDonHang>()
                .HasKey(e => e.MaChiTietDonHang);

            modelBuilder.Entity<BangChiTietTienNo>()
                .HasKey(e => e.IdBangChiTietTienNo);
            
            modelBuilder.Entity<BangDanhSachDonHang>()
                .HasKey(e => e.MaDonHang);
            
            modelBuilder.Entity<BangGiaHan>()
                .HasKey(e => e.Id);
            
            modelBuilder.Entity<BangGiaViThuoc>()
                .HasKey(e => e.MaGiaThuoc);
            
            modelBuilder.Entity<BangKhachHang>()
                .HasKey(e => e.IdBangKhachHang);
            
            modelBuilder.Entity<BangViThuoc>()
                .HasKey(e => e.MaViThuoc);
            
            modelBuilder.Entity<TblHistoryInDepot>()
                .HasKey(e => e.Id);
            
            modelBuilder.Entity<TblJson>()
                .HasKey(e => e.Id);
            
            modelBuilder.Entity<TblJsonPrintOrder>()
                .HasKey(e => e.Id);
            
            modelBuilder.Entity<TblListNameCustomer>()
                .HasKey(e => e.Id);
            
            modelBuilder.Entity<TblListPost>()
                .HasKey(e => e.Id);
            
            modelBuilder.Entity<TblListProductInDepot>()
                .HasKey(e => e.Id);
            
            

            //modelBuilder.Entity<BangAccount>()
            //    .Property(e => e.Id).ValueGeneratedOnAdd();
            
            //modelBuilder.Entity<TblCategoryTheLoai>()
            //    .Property(e => e.MetaTitle)
            //    .IsUnicode(false);

            //modelBuilder.Entity<TblCategoryTheLoai>()
            //    .Property(e => e.CreatedBy)
            //    .IsUnicode(false);

            //modelBuilder.Entity<TblCategoryTheLoai>()
            //    .Property(e => e.ModifiedBy)
            //    .IsUnicode(false);

            //modelBuilder.Entity<TblHtmlRaw>()
            //    .Property(e => e.Keyword)
            //    .IsUnicode(false);

            //modelBuilder.Entity<TblHtmlRaw>()
            //    .Property(e => e.CreatedBy)
            //    .IsUnicode(false);

            //modelBuilder.Entity<TblHtmlRaw>()
            //    .Property(e => e.ModifiedBy)
            //    .IsUnicode(false);

            //modelBuilder.Entity<TblJson>()
            //    .Property(e => e.Keyword)
            //    .IsUnicode(false);

            //modelBuilder.Entity<TblJson>()
            //    .Property(e => e.CreatedBy)
            //    .IsUnicode(false);

            //modelBuilder.Entity<TblJson>()
            //    .Property(e => e.ModifiedBy)
            //    .IsUnicode(false);

            //modelBuilder.Entity<TblPostBaiViet>()
            //    .Property(e => e.MetaTitle)
            //    .IsUnicode(false);

            //modelBuilder.Entity<TblPostBaiViet>()
            //    .Property(e => e.CreatedBy)
            //    .IsUnicode(false);

            //modelBuilder.Entity<TblPostBaiViet>()
            //    .Property(e => e.ModifiedBy)
            //    .IsUnicode(false);

            //modelBuilder.Entity<TblTaiKhoan>()
            //    .Property(e => e.UserName)
            //    .IsUnicode(false);

            //modelBuilder.Entity<TblTaiKhoan>()
            //    .Property(e => e.Password)
            //    .IsUnicode(false);

            //modelBuilder.Entity<TblTaiKhoan>()
            //    .Property(e => e.CreatedBy)
            //    .IsUnicode(false);

            //modelBuilder.Entity<TblTaiKhoan>()
            //    .Property(e => e.ModifiedBy)
            //    .IsUnicode(false);
        }

    }
}

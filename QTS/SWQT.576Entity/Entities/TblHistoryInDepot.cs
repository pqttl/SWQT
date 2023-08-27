namespace SWQT._576Entity.Entities
{
    public class TblHistoryInDepot
    {
        public long Id { get; set; }
        public long IdTblListProductInDepot { get; set; }
        public string? Json { get; set; }
        public string? JsonDonHang { get; set; }
        public double SoLuongTruocKhiSua { get; set; }
        public string? LyDoSuaSoLuong { get; set; }
        public double SoLuongSuaCuThe { get; set; }
        public double SoLuongSauKhiSua { get; set; }
        public string? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public long Status { get; set; }
    }
}

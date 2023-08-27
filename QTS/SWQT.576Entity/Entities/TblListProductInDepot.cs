namespace SWQT._576Entity.Entities
{
    public class TblListProductInDepot
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Json { get; set; }
        public long MaViThuoc { get; set; }
        public double QuantityCurrent { get; set; }
        public double MinQuantity { get; set; }
        public string? DonVi { get; set; }
        public string? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public long Status { get; set; }
    }
}

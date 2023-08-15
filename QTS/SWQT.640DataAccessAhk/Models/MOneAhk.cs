namespace SWQT._640DataAccessAhk.Models
{
    public class MOneAhk
    {
        public int IntId { get; set; } = 0;

        public string StrTitle { get; set; } = "";

        public string StrCode { get; set; } = "";

        public List<MOneMultiText> LstMultiText { get; set; } = new List<MOneMultiText>();

    }
}

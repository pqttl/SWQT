namespace SWQT._640DataAccessAhk.Models
{
    public class MOneMultiText
    {
        public int IntId { get; set; } = 0;

        public string StrTitle { get; set; } = "";

        public string StrCode { get; set; } = "";

        public List<MChildMultiText> LstChildMultiText { get; set; } = new List<MChildMultiText>();

    }
}

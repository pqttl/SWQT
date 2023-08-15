namespace SWQT._640DataAccessAhk.Models
{
    internal class MInputMsBeginTabEnd
    {
        public int IntMsSleepBegin { get; set; } = 0;

        public int IntSoTabMoiDong { get; set; } = 0;

        public int IntMsSleepEnd { get; set; } = 0;

        public MInputMsBeginTabEnd()
        {
            
        }

        public MInputMsBeginTabEnd(int intBegin,int intTab,int intEnd)
        {
            IntMsSleepBegin = intBegin;
            IntSoTabMoiDong = intTab;
            IntMsSleepEnd = intEnd;
        }
    }
}

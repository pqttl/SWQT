using SWQT._640DataAccessAhk.ListAhk.AhkScrollToClick.F512BeginAhk;
using SWQT._640DataAccessAhk.ListAhk.AhkScrollToClick.F896Button;
using SWQT._640DataAccessAhk.Models;

namespace SWQT._640DataAccessAhk.ListAhk.AhkScrollToClick
{
    internal class AllMultiText
    {

        public MOneAhk OAMain { get; set; } = new MOneAhk();

        public AllMultiText(int intIdInput)
        {
            OAMain.IntId = intIdInput;
            OAMain.StrTitle = nameof(AhkScrollToClick);

            int intIndexIncrease = 0;
            OAMain.LstMultiText.Add((new MTGlobalVariable(++intIndexIncrease)).MTMain);
            OAMain.LstMultiText.Add((new MTManyButton(++intIndexIncrease)).MTMain);
            OAMain.LstMultiText.Add((new MTNutNgoacVuong(++intIndexIncrease)).MTMain);
        }

    }
}

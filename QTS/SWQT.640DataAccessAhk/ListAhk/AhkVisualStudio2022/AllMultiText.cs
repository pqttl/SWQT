using SWQT._640DataAccessAhk.ListAhk.AhkVisualStudio2022.F512BeginAhk;
using SWQT._640DataAccessAhk.ListAhk.AhkVisualStudio2022.F768GUI;
using SWQT._640DataAccessAhk.ListAhk.AhkVisualStudio2022.F896Button;
using SWQT._640DataAccessAhk.ListAhk.AhkVisualStudio2022.F960Function;
using SWQT._640DataAccessAhk.Models;

namespace SWQT._640DataAccessAhk.ListAhk.AhkVisualStudio2022
{
    internal class AllMultiText
    {

        public MOneAhk OAMain { get; set; } = new MOneAhk();

        public AllMultiText(int intIdInput)
        {
            OAMain.IntId = intIdInput;
            OAMain.StrTitle = nameof(AhkVisualStudio2022);

            int intIndexIncrease = 0;
            OAMain.LstMultiText.Add((new MTGlobalVariable(++intIndexIncrease)).MTMain);
            OAMain.LstMultiText.Add((new MTGUIMain(++intIndexIncrease)).MTMain);
            OAMain.LstMultiText.Add((new MTManyButton(++intIndexIncrease)).MTMain);
            OAMain.LstMultiText.Add((new MT768PressDivClass(++intIndexIncrease)).MTMain);
            OAMain.LstMultiText.Add((new MTFloatRightLeft(++intIndexIncrease)).MTMain);
            OAMain.LstMultiText.Add((new MTCopyPasteInBracket(++intIndexIncrease)).MTMain);
            OAMain.LstMultiText.Add((new MTManyFunction(++intIndexIncrease)).MTMain);
        }

    }
}

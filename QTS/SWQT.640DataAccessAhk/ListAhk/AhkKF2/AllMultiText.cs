using SWQT._640DataAccessAhk.ListAhk.AhkKF2.F512BeginAhk;
using SWQT._640DataAccessAhk.ListAhk.AhkKF2.F768GUI;
using SWQT._640DataAccessAhk.ListAhk.AhkKF2.F896Button;
using SWQT._640DataAccessAhk.ListAhk.AhkKF2.F960Function;
using SWQT._640DataAccessAhk.Models;

namespace SWQT._640DataAccessAhk.ListAhk.AhkKF2
{
    internal class AllMultiText
    {

        public MOneAhk OAMain { get; set; } = new MOneAhk();

        public AllMultiText(int intIdInput)
        {
            OAMain.IntId = intIdInput;
            OAMain.StrTitle = nameof(AhkKF2);

            int intIndexIncrease = 0;
            OAMain.LstMultiText.Add((new MTGlobalVariable(++intIndexIncrease)).MTMain);
            OAMain.LstMultiText.Add((new MTGUIMain(++intIndexIncrease)).MTMain);

            OAMain.LstMultiText.Add((new MT256WheelDown(++intIndexIncrease)).MTMain);
            OAMain.LstMultiText.Add((new MT320WheelUp(++intIndexIncrease)).MTMain);
            OAMain.LstMultiText.Add((new MT384MButton(++intIndexIncrease)).MTMain);
            OAMain.LstMultiText.Add((new MT512LShift(++intIndexIncrease)).MTMain);
            OAMain.LstMultiText.Add((new MTManyButton(++intIndexIncrease)).MTMain);
            //OAMain.LstMultiText.Add((new MTFloatRightLeft(++intIndexIncrease)).MTMain);
            //OAMain.LstMultiText.Add((new MTCopyPasteInBracket(++intIndexIncrease)).MTMain);

            OAMain.LstMultiText.Add((new MTManyFunction(++intIndexIncrease)).MTMain);

            OAMain.LstMultiText.Add((new MTButtonIfBan1Vien(++intIndexIncrease)).MTMain);
            OAMain.LstMultiText.Add((new MTButtonIfClickTraiLienTuc(++intIndexIncrease)).MTMain);
        }

    }
}

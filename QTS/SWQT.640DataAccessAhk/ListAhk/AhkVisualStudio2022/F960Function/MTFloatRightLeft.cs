using SWQT._640DataAccessAhk.Models;

namespace SWQT._640DataAccessAhk.ListAhk.AhkVisualStudio2022.F960Function
{
    internal class MTFloatRightLeft
    {

        public MOneMultiText MTMain { get; set; } = new MOneMultiText();

        public MTFloatRightLeft(int intIdInput)
        {
            MTMain.IntId = intIdInput;
            MTMain.StrTitle = nameof(MTFloatRightLeft);

            var lstCodeCommon = new ListCodeCommon();


            string strTemp = "";
            strTemp += $@"
{ListName.FuncFloatLeft.STR}() {{

	GuiControl,Disable, Btn{ListName.FuncFloatLeft.STR}

{lstCodeCommon.StrAltTabThenCheckAppName()}

	Send !{{w}}
	Sleep, 50
	Send {{f}}
	Sleep, 850
	Send ^!#{{Left}}
}}
";

            strTemp += $@"
{ListName.FuncFloatRight.STR}() {{

	GuiControl,Disable, Btn{ListName.FuncFloatRight.STR}

{lstCodeCommon.StrAltTabThenCheckAppName()}

	Send !{{w}}
	Sleep, 50
	Send {{f}}
	Sleep, 850
	Send ^!#{{Right}}
}}
";

            MTMain.StrCode = strTemp;
        }
    }
}

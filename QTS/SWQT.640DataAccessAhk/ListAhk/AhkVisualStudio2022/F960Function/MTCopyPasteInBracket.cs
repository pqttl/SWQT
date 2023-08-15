using SWQT._640DataAccessAhk.Models;

namespace SWQT._640DataAccessAhk.ListAhk.AhkVisualStudio2022.F960Function
{
    internal class MTCopyPasteInBracket
    {

        public MOneMultiText MTMain { get; set; } = new MOneMultiText();

        public MTCopyPasteInBracket(int intIdInput)
        {
            MTMain.IntId = intIdInput;
            MTMain.StrTitle = nameof(MTCopyPasteInBracket);

            var lstCodeCommon = new ListCodeCommon();


            string strTemp = "";
            strTemp += $@"
{ListName.FuncCopyAllCodeInBracket.STR}() {{

	GuiControl,Disable, Btn{ListName.FuncCopyAllCodeInBracket.STR}

{lstCodeCommon.StrAltTabThenCheckAppName()}

	Send ^+{{]}}
	Sleep, 150
	Send ^{{c}}
}}
";

            strTemp += $@"
{ListName.FuncPasteAllCodeInBracket.STR}() {{

	GuiControl,Disable, Btn{ListName.FuncPasteAllCodeInBracket.STR}

{lstCodeCommon.StrAltTabThenCheckAppName()}

	Send ^+{{]}}
	Sleep, 150
	Send ^{{v}}
}}
";

            MTMain.StrCode = strTemp;
        }
    }
}

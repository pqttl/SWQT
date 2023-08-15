using SWQT._640DataAccessAhk.Models;

namespace SWQT._640DataAccessAhk.ListAhk.AhkVisualStudio2022.F960Function
{
    internal class MT768PressDivClass
    {

        public MOneMultiText MTMain { get; set; } = new MOneMultiText();

        public MT768PressDivClass(int intIdInput)
        {
            MTMain.IntId = intIdInput;
            MTMain.StrTitle = nameof(MT768PressDivClass);

            var lstCodeCommon = new ListCodeCommon();


            string strTemp = "";
            strTemp += $@"
{ListName.FuncPressDivClass.STR}() {{

	GuiControl,Disable, Btn{ListName.FuncPressDivClass.STR}

{lstCodeCommon.StrAltTabThenCheckAppName()}

	;SendInput {{Raw}}<div cla
	;Sleep, 50
	;SendInput {{Raw}}ss=""""></div>

    ;temp := clipboardall
    clipboard := ""<div class=""""""""></div>""
	Sleep, 50
    sendinput, ^v
    ;clipboard := temp

	Loop 6
	{{
		send {{left}}
		sleep, 25
	}}
	Send {{enter}}

}}
";

            MTMain.StrCode = strTemp;
        }
    }
}

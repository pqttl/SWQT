using SWQT._640DataAccessAhk.Models;

namespace SWQT._640DataAccessAhk.ListAhk.AhkVisualStudio2022.F960Function
{
    internal class MTManyFunction
    {

        public MOneMultiText MTMain { get; set; } = new MOneMultiText();

        public MTManyFunction(int intIdInput)
        {
            MTMain.IntId = intIdInput;
            MTMain.StrTitle = nameof(MTManyFunction);

			var lstCodeCommon = new ListCodeCommon();


            string strTemp = "";

            strTemp += $@"
VoidPressCtrlNgoacVuongS:
	GuiControl,Disable, BtnCtrlNgoacVuongS

{lstCodeCommon.StrAltTabThenCheckAppName()}

	Send ^{{[}}
	Sleep, 150
	Send ^{{s}}
return
";
            strTemp += $@"
VoidEnableButton() {{
	GuiControl,Enable, Btn{ListName.FuncCopyAllCodeInBracket.STR}
	GuiControl,Enable, Btn{ListName.FuncPasteAllCodeInBracket.STR}
	GuiControl,Enable, Btn{ListName.FuncFloatLeft.STR}
	GuiControl,Enable, Btn{ListName.FuncFloatRight.STR}
	GuiControl,Enable, Btn{ListName.FuncPressDivClass.STR}
	GuiControl,Enable, BtnCtrlNgoacVuongS
}}

do_thing() {{
  Msgbox your just a little confused, not gay.
}}
";
            strTemp += $@"
VoidAltTab(){{
    list := """"
    WinGet, id, list
    Loop, %id%
    {{
        this_ID := id%A_Index%
        IfWinActive, ahk_id %this_ID%
            continue    
        WinGetTitle, title, ahk_id %this_ID%
        If (title = """")
            continue
        If (!IsWindow(WinExist(""ahk_id"" . this_ID))) 
            continue
        WinActivate, ahk_id %this_ID%
        WinWaitActive, ahk_id %this_ID%,,2 
            break
    }}
}}
";
            strTemp += $@"
ActivateTitle:
    SetTitleMatchMode 3
    WinActivate, %A_ThisMenuItem%
return

;-----------------------------------------------------------------
; Check whether the target window is activation target
;-----------------------------------------------------------------
IsWindow(hWnd){{
    WinGet, dwStyle, Style, ahk_id %hWnd%
    if ((dwStyle&0x08000000) || !(dwStyle&0x10000000)) {{
        return false
    }}
    WinGet, dwExStyle, ExStyle, ahk_id %hWnd%
    if (dwExStyle & 0x00000080) {{
        return false
    }}
    WinGetClass, szClass, ahk_id %hWnd%
    if (szClass = ""TApplication"") {{
        return false
    }}
    return true
}}
";

            MTMain.StrCode = strTemp;
        }
    }
}

using SWQT._640DataAccessAhk.Models;

namespace SWQT._640DataAccessAhk.ListAhk.AhkVisualStudio2022.F768GUI
{
    internal class MTGUIMain
    {

        public MOneMultiText MTMain { get; set; } = new MOneMultiText();

        public MTGUIMain(int intIdInput)
        {
            MTMain.IntId = intIdInput;
            MTMain.StrTitle = nameof(MTGUIMain);

            string strTemp = "";

            strTemp += $@"
Gui,+AlwaysOnTop
;Gui, Show, w300 h200 Center, VisualStudioF11F12
Gui, Show, x1500 y865 w220 h140 , VisualStudioF11F12
";
            
            strTemp += $@"
Gui, Add, Button, Default x10 y11 w80 vBtn{ListName.FuncCopyAllCodeInBracket.STR} g{ListName.FuncCopyAllCodeInBracket.STR}, CopyTrongNgoac

Gui, Add, Button, Default x110 y11 w80 vBtn{ListName.FuncPasteAllCodeInBracket.STR} g{ListName.FuncPasteAllCodeInBracket.STR}, PasteTrongNgoac
";
            
            strTemp += $@"
Gui, Add, Button, Default x10 y33 w80 vBtn{ListName.FuncFloatLeft.STR} g{ListName.FuncFloatLeft.STR}, FloatLeft

Gui, Add, Button, Default x110 y33 w80 vBtn{ListName.FuncFloatRight.STR} g{ListName.FuncFloatRight.STR}, FloatRight
";

            strTemp += $@"
Gui, Add, Button, Default x10 y55 w110 vBtn{ListName.FuncPressDivClass.STR} g{ListName.FuncPressDivClass.STR}, PressDivClass
";

            strTemp += $@"
Gui, Add, Button, Default x10 y77 w140 vBtnCtrlNgoacVuongS gVoidPressCtrlNgoacVuongS, Sync (Ctrl+[ va Ctrl+S)
Gui, Add, Button, Default w110 gVoidEnableButton, EnableAllButton
return

GuiClose:
ExitApp

#MaxThreadsPerHotkey 2
";

            MTMain.StrCode = strTemp;
        }
    }
}

using SWQT._640DataAccessAhk.Models;

namespace SWQT._640DataAccessAhk.ListAhk.AhkScrollToClick.F512BeginAhk
{
    internal class MTGlobalVariable
    {

        public MOneMultiText MTMain { get; set; } = new MOneMultiText();

        public MTGlobalVariable(int intIdInput)
        {
            MTMain.IntId = intIdInput;
            MTMain.StrTitle = nameof(MTGlobalVariable);
            MTMain.StrCode = @"
#InstallKeybdHook
#UseHook

boolDangChay=0
boolDangChayDown=0

Gui, Show, w300 h200, MyGui
return

GuiClose:
ExitApp

#MaxThreadsPerHotkey 2

;mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm
";
        }
    }
}

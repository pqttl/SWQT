using SWQT._640DataAccessAhk.Models;

namespace SWQT._640DataAccessAhk.ListAhk.AhkVisualStudio2022.F512BeginAhk
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

keepIT := ""WindowAutoHotkeyScript.ahk"" ;keep this script alive but close all others
keepIT2 := ""MyScript.ahk""

for process in ComObjGet(""winmgmts:"").ExecQuery(""Select * from Win32_Process where name = 'Autohotkey.exe' 
and not (CommandLine like '%"" keepIT ""%' or Commandline like '%"" keepIT2 ""%')"")
	process, close, % process.ProcessId
";
        }
    }
}

using SWQT._640DataAccessAhk.Models;

namespace SWQT._640DataAccessAhk.ListAhk.AhkKF2.F512BeginAhk
{
    internal class MTGlobalVariable
    {

        public MOneMultiText MTMain { get; set; } = new MOneMultiText();

        public MTGlobalVariable(int intIdInput)
        {
            MTMain.IntId = intIdInput;
            MTMain.StrTitle = nameof(MTGlobalVariable);

            string strTemp = "";
            strTemp += $@"
;DetectHiddenWindows, On
;Run, steam://rungameid/232090
;sleep, 30000
;WinWaitClose, ahk_exe KFGame.exe
;ExitApp

#SingleInstance force 
If 1 = /exit
   ExitApp

KichHoatF5=1
Ban1Vien=1
ClickTraiLienTuc=0
KichHoatF6=0

Bool001DangLButton=0
Bool002LightAttackLienTuc=0
Bool003HardAttackLienTuc=0
Bool004HardAttack1Lan=0

Bool005DangScrollUp=0

Bool006DiThangLienTuc=0

Bool007CLienTuc=0

Bool008EAttackVertical=0

Bool009DangScrollDown=0
";

            MTMain.StrCode = strTemp;
        }
    }
}

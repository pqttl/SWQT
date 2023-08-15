using SWQT._640DataAccessAhk.Models;

namespace SWQT._640DataAccessAhk.ListAhk.AhkKF2.F768GUI
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
Gui, Add, Checkbox, gVoidCheckboxKichHoatF5Changed vVarIdChkButton1 checked, Kích hoạt F5 khi chuyển 1 thì bắn từng viên KichHoatF5
Gui, Add, Checkbox, gVoidCheckboxKichHoatF5Changed vVarIdChkButton2 checked, Bắn từng viên và có thể press 4 liên tục Ban1Vien
Gui, Add, Checkbox, gVoidCheckboxKichHoatF5Changed vVarIdChkButton3, Giữ left mouse để click trái liên tục và press 4 auto W attack ClickTraiLienTuc
Gui, Add, Checkbox, gVoidCheckboxKichHoatF5Changed vVarIdChkButton4, Kích hoạt F6 khi chuyển 1 thì bắn từng 2 viên bỏ qua F5 KichHoatF6
Gui, Add, Checkbox, gVoidCheckboxKichHoatF5Changed vVarIdChkButton5, Scroll up tự động click trái Bool002LightAttackLienTuc ClickTraiLienTuc

Gui, Add, Text,, Noi dung:
Gui, Add, Text,, Press num/ de vut 500 tien - phim c de slow speed
Gui, Add, Text,, Press End de vut het roi suicide - Num* nhin len tren - Num- nhin len tren vut tien - Num+ nhin thang
Gui, Add, Text,, Num9 help boss - num7 bash cancel - num6show console boss id - num 5 hold up - num3 dance - num2 need biggun 
Gui, Add, Text,, Ctrl num9 i suicide by button - ctrl num6 click left - ctrl num4 num0 show message boss
Gui, Add, Text,, Giu shift de cancel parry lien tuc
Gui, Add, Text,, Scroll up de E lien tuc khi chon vu khi 1(Ko Can gan phim c bash cancel)
Gui, Add, Text,, Four ban 1 vien customfiremode 1
Gui, Add, Text,, Scroll down de click trai sleep 500 va thay dan, stop E vu khi 1

Gui, Show, w700 h380, MyGui
return

VoidCheckboxKichHoatF5Changed:
return

GuiClose:
ExitApp

#MaxThreadsPerHotkey 1
";

            MTMain.StrCode = strTemp;
        }
    }
}

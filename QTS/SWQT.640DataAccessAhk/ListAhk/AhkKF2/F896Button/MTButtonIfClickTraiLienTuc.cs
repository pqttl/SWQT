using SWQT._640DataAccessAhk.Models;

namespace SWQT._640DataAccessAhk.ListAhk.AhkKF2.F896Button
{
    internal class MTButtonIfClickTraiLienTuc
    {

        public MOneMultiText MTMain { get; set; } = new MOneMultiText();

        public MTButtonIfClickTraiLienTuc(int intIdInput)
        {
            MTMain.IntId = intIdInput;
            MTMain.StrTitle = nameof(MTButtonIfClickTraiLienTuc);

            //var lstCodeCommon = new ListCodeCommon();


            string strTemp = "";
            strTemp += $@"
#if (ClickTraiLienTuc)

LButton::
Bool002LightAttackLienTuc=0
while GetKeyState(""LButton"",""P"")
{{
If Bool001DangLButton=1
	Bool001DangLButton=1
else
{{
	Bool001DangLButton=1
	send {{RCtrl down}}
	send {{Numpad6 down}}
	sleep, 200
	send {{Numpad6 up}}
	send {{RCtrl up}}
	Bool001DangLButton=0
}}
}}
return

4::
while GetKeyState(""4"",""P"")
{{
send {{4 down}}
sleep, 10
send {{4 up}}
sleep, 40
}}
return

Numpad8::
If Bool008EAttackVertical=0
	Bool008EAttackVertical=1
Else
{{
	Bool008EAttackVertical=0
	If ClickTraiLienTuc=1
	{{
	send {{2}}
	send {{3}}
	}}
}}
return

~r::
Bool002LightAttackLienTuc=0
Bool003HardAttackLienTuc=0
	If (ClickTraiLienTuc=0 and Bool005DangScrollUp=0)
	{{
	Bool005DangScrollUp=1
	send {{XButton1 down}}
	sleep, 410
	send {{XButton1 up}}
	Bool005DangScrollUp=0	
	}}
GoSub, VoidHienThiCheckboxTheoBien
return


";

            MTMain.StrCode = strTemp;
        }
    }
}

using SWQT._640DataAccessAhk.Models;

namespace SWQT._640DataAccessAhk.ListAhk.AhkKF2.F896Button
{
    internal class MTButtonIfBan1Vien
    {

        public MOneMultiText MTMain { get; set; } = new MOneMultiText();

        public MTButtonIfBan1Vien(int intIdInput)
        {
            MTMain.IntId = intIdInput;
            MTMain.StrTitle = nameof(MTButtonIfBan1Vien);

            //var lstCodeCommon = new ListCodeCommon();


            string strTemp = "";
            strTemp += $@"





#if (Ban1Vien)

LButton::
If Bool001DangLButton=1
	return
Bool001DangLButton=1

If KichHoatF6=1
{{
	click
	sleep, 200
	click
}}
else
{{
	click
}}

Bool001DangLButton=0
return

4::
while GetKeyState(""4"",""P"")
{{
send {{x}}
sleep, 45

}}
return

~y::
~r::
Bool002LightAttackLienTuc=0
Bool003HardAttackLienTuc=0
Bool007CLienTuc=0
return
";

            MTMain.StrCode = strTemp;
        }
    }
}

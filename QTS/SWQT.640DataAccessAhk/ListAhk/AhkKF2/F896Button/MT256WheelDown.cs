using SWQT._640DataAccessAhk.Models;

namespace SWQT._640DataAccessAhk.ListAhk.AhkKF2.F896Button
{
    internal class MT256WheelDown
    {

        public MOneMultiText MTMain { get; set; } = new MOneMultiText();

        public MT256WheelDown(int intIdInput)
        {
            MTMain.IntId = intIdInput;
            MTMain.StrTitle = nameof(MT256WheelDown)+ " Bouncer2V Headhunter rồi Q";

            //var lstCodeCommon = new ListCodeCommon();


            string strTemp = "";
            strTemp += $@"";
            strTemp += $@"
WheelDown::
If Bool009DangScrollDown=1
return

If Bool007CLienTuc=1
{{
	Bool009DangScrollDown=1
	Bool007CLienTuc=0
	sleep, 100
	Bool009DangScrollDown=0	
	return
}}

Bool002LightAttackLienTuc=0
Bool003HardAttackLienTuc=0
If (ClickTraiLienTuc=0 and Bool009DangScrollDown=0 and Bool007CLienTuc=0)
{{
	Bool009DangScrollDown=1

	send {{XButton1 down}}
	sleep, 210
	send {{XButton1 up}}
	sleep, 0
	send {{q}}
	sleep, 10
	send {{XButton1 down}}
	sleep, 10
	send {{XButton1 up}}

	Bool009DangScrollDown=0	
}}
GoSub, VoidHienThiCheckboxTheoBien
return
";

            MTMain.StrCode = strTemp;
        }
    }
}

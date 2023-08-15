using SWQT._640DataAccessAhk.Models;

namespace SWQT._640DataAccessAhk.ListAhk.AhkKF2.F896Button
{
    internal class MT320WheelUp
    {

        public MOneMultiText MTMain { get; set; } = new MOneMultiText();

        public MT320WheelUp(int intIdInput)
        {
            MTMain.IntId = intIdInput;
            MTMain.StrTitle = nameof(MT320WheelUp)+" FrostCancel";

            //var lstCodeCommon = new ListCodeCommon();


            string strTemp = "";
            strTemp += $@"";
            strTemp += $@"
WheelUp::
If ClickTraiLienTuc=0
{{
	Bool002LightAttackLienTuc=0
	Bool003HardAttackLienTuc=0
	
	If (ClickTraiLienTuc=0 and Bool005DangScrollUp=0)
	{{
	Bool005DangScrollUp=1
	Bool007CLienTuc=1
	while (Bool007CLienTuc=1 and ClickTraiLienTuc=0)
	{{
	send {{Up down}}
	sleep, 20
	send {{Numpad7}}
	sleep, 20
	send {{Down down}}
	send {{Up up}}
	sleep, 40
	send {{Down up}}
	sleep, 300
	}}
	Bool005DangScrollUp=0	
	}}

	return
}}
If Bool002LightAttackLienTuc=0
	Bool002LightAttackLienTuc=1
	
GoSub, VoidHienThiCheckboxTheoBien

;Bool008EAttackVertical=1
while (Bool002LightAttackLienTuc=1 and ClickTraiLienTuc=1)
{{
	If Bool004HardAttack1Lan=1
		continue

	If Bool008EAttackVertical=1
	{{
	send {{Up down}}
	send {{XButton1 down}}
	;sleep, 100
	send {{Up up}}
	send {{Down down}}
	send {{XButton1 up}}
	send {{Down up}}
	sleep, 50
	continue
	}}
	
	If Bool008EAttackVertical=0
	{{
	send {{XButton1 down}}
	send {{XButton1 up}}
	sleep, 50
	continue
	}}
}}
Bool002LightAttackLienTuc=0
GoSub, VoidHienThiCheckboxTheoBien
return
";

            MTMain.StrCode = strTemp;
        }
    }
}

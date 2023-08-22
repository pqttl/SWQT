using SWQT._640DataAccessAhk.Models;

namespace SWQT._640DataAccessAhk.ListAhk.AhkKF2.F896Button
{
    internal class MT384MButton
    {

        public MOneMultiText MTMain { get; set; } = new MOneMultiText();

        public MT384MButton(int intIdInput)
        {
            MTMain.IntId = intIdInput;
            MTMain.StrTitle = nameof(MT384MButton);

            //var lstCodeCommon = new ListCodeCommon();


            string strTemp = "";
            strTemp += $@"";

            MTMain.StrCode = strTemp;

            int intIndexIncrease = 0;
            MTMain.LstChildMultiText.Add(new MChildMultiText()
            {
                IntId = ++intIndexIncrease
                ,
                StrTitle = "Mine 6V huskCannon 5V"
                ,
                StrCode = $@"
MButton::
Bool007CLienTuc=0
If ClickTraiLienTuc=0
{{
    Bool002LightAttackLienTuc=0
    Bool003HardAttackLienTuc=0
    If (ClickTraiLienTuc=0 and Bool005DangScrollUp=0)
    {{
	    Bool005DangScrollUp=1
	    send {{XButton1 down}}
	    sleep, 1420
	    send {{XButton1 up}}
	    Bool005DangScrollUp=0	
    }}
    return
}}
If Bool003HardAttackLienTuc=0
	Bool003HardAttackLienTuc=1
	
GoSub, VoidHienThiCheckboxTheoBien
while (Bool003HardAttackLienTuc=1 and ClickTraiLienTuc=1)
{{
	;send {{XButton1 down}}
	send {{XButton2 down}}
	sleep, 350
	;send {{XButton1 up}}
	send {{XButton2 up}}
}}
Bool003HardAttackLienTuc=0
GoSub, VoidHienThiCheckboxTheoBien
return
"
            });
            
            MTMain.LstChildMultiText.Add(new MChildMultiText()
            {
                IntId = ++intIndexIncrease
                ,
                StrTitle = "Mine và huskCannon 4V, Bouncer 8V"
                ,
                StrCode = $@"
MButton::
Bool007CLienTuc=0
If ClickTraiLienTuc=0
{{
    Bool002LightAttackLienTuc=0
    Bool003HardAttackLienTuc=0
    If (ClickTraiLienTuc=0 and Bool005DangScrollUp=0)
    {{
	    Bool005DangScrollUp=1
	    send {{XButton1 down}}
	    sleep, 940
	    send {{XButton1 up}}
	    Bool005DangScrollUp=0	
    }}
    return
}}
If Bool003HardAttackLienTuc=0
	Bool003HardAttackLienTuc=1
	
GoSub, VoidHienThiCheckboxTheoBien
while (Bool003HardAttackLienTuc=1 and ClickTraiLienTuc=1)
{{
	;send {{XButton1 down}}
	send {{XButton2 down}}
	sleep, 350
	;send {{XButton1 up}}
	send {{XButton2 up}}
}}
Bool003HardAttackLienTuc=0
GoSub, VoidHienThiCheckboxTheoBien
return
"
            });
            
            MTMain.LstChildMultiText.Add(new MChildMultiText()
            {
                IntId = ++intIndexIncrease
                ,
                StrTitle = "Mine và huskCannon 3V, Bouncer 6V"
                ,
                StrCode = $@"
MButton::
Bool007CLienTuc=0
If ClickTraiLienTuc=0
{{
    Bool002LightAttackLienTuc=0
    Bool003HardAttackLienTuc=0
    If (ClickTraiLienTuc=0 and Bool005DangScrollUp=0)
    {{
	    Bool005DangScrollUp=1
	    send {{XButton1 down}}
	    sleep, 710
	    send {{XButton1 up}}
	    Bool005DangScrollUp=0	
    }}
    return
}}
If Bool003HardAttackLienTuc=0
	Bool003HardAttackLienTuc=1
	
GoSub, VoidHienThiCheckboxTheoBien
while (Bool003HardAttackLienTuc=1 and ClickTraiLienTuc=1)
{{
	;send {{XButton1 down}}
	send {{XButton2 down}}
	sleep, 350
	;send {{XButton1 up}}
	send {{XButton2 up}}
}}
Bool003HardAttackLienTuc=0
GoSub, VoidHienThiCheckboxTheoBien
return
"
            });
            
            MTMain.LstChildMultiText.Add(new MChildMultiText()
            {
                IntId = ++intIndexIncrease
                ,
                StrTitle = "Mine và huskCannon 2V, Bouncer 4V"
                ,
                StrCode = $@"
MButton::
Bool007CLienTuc=0
If ClickTraiLienTuc=0
{{
    Bool002LightAttackLienTuc=0
    Bool003HardAttackLienTuc=0
    If (ClickTraiLienTuc=0 and Bool005DangScrollUp=0)
    {{
	    Bool005DangScrollUp=1
	    send {{XButton1 down}}
	    sleep, 475
	    send {{XButton1 up}}
	    Bool005DangScrollUp=0	
    }}
    return
}}
If Bool003HardAttackLienTuc=0
	Bool003HardAttackLienTuc=1
	
GoSub, VoidHienThiCheckboxTheoBien
while (Bool003HardAttackLienTuc=1 and ClickTraiLienTuc=1)
{{
	;send {{XButton1 down}}
	send {{XButton2 down}}
	sleep, 350
	;send {{XButton1 up}}
	send {{XButton2 up}}
}}
Bool003HardAttackLienTuc=0
GoSub, VoidHienThiCheckboxTheoBien
return
"
            });
            
            MTMain.LstChildMultiText.Add(new MChildMultiText()
            {
                IntId = ++intIndexIncrease
                ,
                StrTitle = "Thermitte Firebug rồi Q"
                ,
                StrCode = $@"
MButton::
Bool007CLienTuc=0
If ClickTraiLienTuc=0
{{
    Bool002LightAttackLienTuc=0
    Bool003HardAttackLienTuc=0
	If (ClickTraiLienTuc=0 and Bool005DangScrollUp=0)
	{{
	    Bool005DangScrollUp=1
	    send {{XButton1 down}}
	    sleep, 0
	    send {{XButton1 up}}
	    sleep, 780
	    send {{q}}
	    sleep, 50
	    send {{q}}
	    sleep, 50
	    send {{XButton1 down}}
	    sleep, 0
	    send {{XButton1 up}}
	    Bool005DangScrollUp=0	
	}}
    return
}}
If Bool003HardAttackLienTuc=0
	Bool003HardAttackLienTuc=1
	
GoSub, VoidHienThiCheckboxTheoBien
while (Bool003HardAttackLienTuc=1 and ClickTraiLienTuc=1)
{{
	send {{XButton2 down}}
	sleep, 350
	send {{XButton2 up}}
}}
Bool003HardAttackLienTuc=0
GoSub, VoidHienThiCheckboxTheoBien
return
"
            });

        }
    }
}

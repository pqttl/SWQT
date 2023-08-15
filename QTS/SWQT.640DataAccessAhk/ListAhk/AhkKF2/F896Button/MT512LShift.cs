using SWQT._640DataAccessAhk.Models;

namespace SWQT._640DataAccessAhk.ListAhk.AhkKF2.F896Button
{
    internal class MT512LShift
    {

        public MOneMultiText MTMain { get; set; } = new MOneMultiText();

        public MT512LShift(int intIdInput)
        {
            MTMain.IntId = intIdInput;
            MTMain.StrTitle = nameof(MT512LShift);

            //var lstCodeCommon = new ListCodeCommon();


            string strTemp = "";
            strTemp += $@"";

            MTMain.StrCode = strTemp;

            int intIndexIncrease = 0;
            MTMain.LstChildMultiText.Add(new MChildMultiText()
            {
                IntId = ++intIndexIncrease
                ,
                StrTitle = "Mine và huskCannon 6V"
                ,
                StrCode = $@"
LShift::
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
LShift::
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
LShift::
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
LShift::
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
LShift::
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

return
"
            });
            
            MTMain.LstChildMultiText.Add(new MChildMultiText()
            {
                IntId = ++intIndexIncrease
                ,
                StrTitle = "For demo shot 7 bullet"
                ,
                StrCode = $@"
LShift::
Bool007CLienTuc=0
If ClickTraiLienTuc=0
{{
    Bool002LightAttackLienTuc=0
    Bool003HardAttackLienTuc=0
	If (ClickTraiLienTuc=0 and Bool005DangScrollUp=0)
	{{
	    Bool005DangScrollUp=1
	    send {{XButton1 down}}
	    sleep, 945
	    send {{XButton1 up}}
	    Bool005DangScrollUp=0	
	}}
    return
}}

return
"
            });

            MTMain.LstChildMultiText.Add(new MChildMultiText()
            {
                IntId = ++intIndexIncrease
                ,
                StrTitle = "Parry liên tục"
                ,
                StrCode = $@"
LShift::
while GetKeyState(""LShift"",""P"")
{{
	send {{e}}
	sleep, 50
	send {{q}}
	sleep, 50
}}
"
            });

        }
    }
}

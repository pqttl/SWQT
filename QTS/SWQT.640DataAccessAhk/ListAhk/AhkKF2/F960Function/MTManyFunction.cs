using SWQT._640DataAccessAhk.Models;

namespace SWQT._640DataAccessAhk.ListAhk.AhkKF2.F960Function
{
    internal class MTManyFunction
    {

        public MOneMultiText MTMain { get; set; } = new MOneMultiText();

        public MTManyFunction(int intIdInput)
        {
            MTMain.IntId = intIdInput;
            MTMain.StrTitle = nameof(MTManyFunction);

            //var lstCodeCommon = new ListCodeCommon();


            string strTemp = "";
            strTemp += $@"


; ------------------------ Các GoSub Void Begin ----------------------------

;Biến cục bộ không hiểu số 1 nên dùng cách này
VoidSet3BienKichHoat(intActiveF5,intShotOne,intClickTrai){{
global KichHoatF5:=1
global Ban1Vien:=1
global ClickTraiLienTuc:=1
If intActiveF5=0
global KichHoatF5:=%intActiveF5%
If intShotOne=0
global Ban1Vien:=%intShotOne%
If intClickTrai=0
global ClickTraiLienTuc:=%intClickTrai%
}}

;Biến cục bộ không hiểu số 1 nên dùng cách này
VoidSet2BienKichHoatF5Ban1Shot(intActiveF5,intShotOne){{
global KichHoatF5:=1
global Ban1Vien:=1
If intActiveF5=0
global KichHoatF5:=%intActiveF5%
If intShotOne=0
global Ban1Vien:=%intShotOne%
}}

VoidHienThiCheckboxTheoBien:
If KichHoatF5 = 1
  Control, check,, Button1, MyGui
else
  Control, uncheck,, Button1, MyGui

If Ban1Vien = 1
  Control, check,, Button2, MyGui
else
  Control, uncheck,, Button2, MyGui

If ClickTraiLienTuc = 1
  Control, check,, Button3, MyGui
else
  Control, uncheck,, Button3, MyGui

If KichHoatF6 = 1
  Control, check,, Button4, MyGui
else
  Control, uncheck,, Button4, MyGui

If (Bool002LightAttackLienTuc = 1 and ClickTraiLienTuc = 1)
  Control, check,, Button5, MyGui
else
  Control, uncheck,, Button5, MyGui
return

; ------------------------ Các GoSub Void End ----------------------------



";

            MTMain.StrCode = strTemp;
        }
    }
}

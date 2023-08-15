using SWQT._640DataAccessAhk.Models;

namespace SWQT._640DataAccessAhk.ListAhk.AhkKF2.F896Button
{
    internal class MTManyButton
    {

        public MOneMultiText MTMain { get; set; } = new MOneMultiText();

        public MTManyButton(int intIdInput)
        {
            MTMain.IntId = intIdInput;
            MTMain.StrTitle = nameof(MTManyButton);

            string strTemp = "";

            strTemp += $@"
; ------------------------ Các sự kiện button press Begin ----------------------------

F4::
;VoidSet2BienKichHoatF5Ban1Shot(0,0)
VoidSet3BienKichHoat(0,0,0)
KichHoatF6=0
GoSub, VoidHienThiCheckboxTheoBien
return

F5::
;VoidSet2BienKichHoatF5Ban1Shot(1,1)
VoidSet3BienKichHoat(1,1,0)
KichHoatF6=0
GoSub, VoidHienThiCheckboxTheoBien
return

F6::
;VoidSet2BienKichHoatF5Ban1Shot(1,1)
VoidSet3BienKichHoat(1,1,0)
KichHoatF6=1
GoSub, VoidHienThiCheckboxTheoBien
return

~1::
Bool007CLienTuc=0
ClickTraiLienTuc=0
If (KichHoatF5=1)
	Ban1Vien=1
Else
	Ban1Vien=0
GoSub, VoidHienThiCheckboxTheoBien
return

~E::
Bool007CLienTuc=0
return

~Escape::
~F::
~O::
Bool007CLienTuc=0
VoidSet3BienKichHoat(1,1,0)
KichHoatF6=0
GoSub, VoidHienThiCheckboxTheoBien
return

~2::
Bool007CLienTuc=0
ClickTraiLienTuc=0
If (KichHoatF5=1)
	Ban1Vien=1
Else
	Ban1Vien=0
;Ban1Vien=0
GoSub, VoidHienThiCheckboxTheoBien
return

~3::
ClickTraiLienTuc=1
Ban1Vien=0
GoSub, VoidHienThiCheckboxTheoBien
return

F11::
Bool007CLienTuc=0
Bool006DiThangLienTuc=0

VoidSet3BienKichHoat(1,1,0)
KichHoatF6=0
GoSub, VoidHienThiCheckboxTheoBien
send ``
sleep, 50
SendInput {{Raw}}disconnect
sleep, 50
send {{Enter}}
sleep, 50
send ``
return

Numpad6::
send ``
sleep, 50
SendInput {{Raw}}getall KFGameReplicationInfo BossIndex
sleep, 50
send {{Enter}}
;sleep, 50
;send ``
return

End::
;send {{1}}
;sleep, 50
Loop 8
{{
	Loop 1
	{{
		send {{F3}}
		sleep, 25
	}}
	Loop 0
	{{
		send {{b}}
		sleep, 30
	}}
}}
Loop 30
	{{
		send {{b}}
		sleep, 25
	}}
Loop 1
	{{
		send {{6}}
		sleep, 425
		send {{F3}}
		sleep, 25
	}}
;send ^{{Numpad9}}
;sleep, 50
;send {{delete}}
return

~RButton::
Bool004HardAttack1Lan=1

;Bool002LightAttackLienTuc=0
Bool003HardAttackLienTuc=0

sleep, 1000
Bool004HardAttack1Lan=0

GoSub, VoidHienThiCheckboxTheoBien
return

; ------------------------ Các sự kiện button press End ----------------------------


";

            MTMain.StrCode = strTemp;
        }
    }
}

using SWQT._640DataAccessAhk.Models;

namespace SWQT._640DataAccessAhk.ListAhk.AhkScrollToClick.F896Button
{
    internal class MTManyButton
    {

        public MOneMultiText MTMain { get; set; } = new MOneMultiText();

        public MTManyButton(int intIdInput)
        {
            MTMain.StrTitle = nameof(MTManyButton);
            MTMain.IntId = intIdInput;
            MTMain.StrCode = @"
WheelUp::
If boolDangChay=1
	return
boolDangChay=1
send {click Left}
sleep, 500
boolDangChay=0
return

WheelDown::
If boolDangChayDown=1
	return
boolDangChayDown=1
send {click Right}
sleep, 500
boolDangChayDown=0
return

+WheelUp::
send {WheelUp}
return

+WheelDown::
send {WheelDown}
return
";
        }
    }
}

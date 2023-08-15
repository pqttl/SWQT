using SWQT._640DataAccessAhk.Models;

namespace SWQT._640DataAccessAhk.ListAhk.AhkScrollToClick.F896Button
{
    internal class MTNutNgoacVuong
    {

        public MOneMultiText MTMain { get; set; } = new MOneMultiText();

        public MTNutNgoacVuong(int intIdInput)
        {
            MTMain.StrTitle = nameof(MTNutNgoacVuong);
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

            int intIndexIncrease = 0;
            MTMain.LstChildMultiText.Add(new MChildMultiText()
            {
                IntId=++intIndexIncrease
                ,StrTitle= "PgDn là [ trái, PgUp là ] phải"
                ,
                StrCode= @"
[::PgDn
]::PgUp
"
            });

            MTMain.LstChildMultiText.Add(new MChildMultiText()
            {
                IntId = ++intIndexIncrease
                ,
                StrTitle = "PgUp là [ trái, PgDn là ] phải"
                ,
                StrCode = @"
[::PgUp
]::PgDn
"
            });

        }
    }
}

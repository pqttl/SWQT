using SWQT._640DataAccessAhk.Models;

namespace SWQT._640DataAccessAhk.ListAhk.AhkSample
{
    internal class AllMultiText
    {

        public MOneAhk OAMain { get; set; } = new MOneAhk();

        public AllMultiText(int intIdInput)
        {
            OAMain.IntId = intIdInput;
            OAMain.StrTitle = nameof(AhkSample);
            var mTemp = new MOneMultiText();
            mTemp.IntId = 1;
            mTemp.StrTitle = "Script";
            mTemp.StrCode = @"
#InstallKeybdHook
#UseHook

boolDangChay=0
boolDangChayDown=0

Gui, Show, w300 h200, MyGui
return

GuiClose:
ExitApp

#MaxThreadsPerHotkey 2

;mmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmm

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

[::PgUp
]::PgDn
";
            OAMain.LstMultiText.Add(mTemp);
        }

    }
}

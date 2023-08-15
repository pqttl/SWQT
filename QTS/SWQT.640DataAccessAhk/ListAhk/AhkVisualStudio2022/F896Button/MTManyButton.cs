using SWQT._640DataAccessAhk.Models;

namespace SWQT._640DataAccessAhk.ListAhk.AhkVisualStudio2022.F896Button
{
    internal class MTManyButton
    {

        public MOneMultiText MTMain { get; set; } = new MOneMultiText();

        public MTManyButton(int intIdInput)
        {
            MTMain.IntId = intIdInput;
            MTMain.StrTitle = nameof(MTManyButton);
            MTMain.StrCode = @"
;RControl & PrintScreen::PrintScreen
PrintScreen::f12
NumLock::f11
;RControl & Left::Home
;RControl & Right::End
;>^Up::Send {PgUp}
;>^Down::Send {PgDn}


;RControl & Delete::PrintScreen
";
        }
    }
}

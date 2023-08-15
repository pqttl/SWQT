using SWQT._640DataAccessAhk.Models;

namespace SWQT._640DataAccessAhk.ListAhk.AhkVisualStudio2022
{
    internal class ListCodeCommon
    {

        public string StrOneTab { get; set; } = "\t";

        public ListCodeCommon()
        {
            //StrOneTab = StrCheckAppName(50,1,0);
        }

        #region List code

        internal string StrCheckAppName(MInputMsBeginTabEnd mInput)
        {
            string strOutput = "";
            strOutput += "";

            strOutput += $@"
Winget,AppName,ProcessName,A

If !(AppName = ""devenv.exe"")
{{
Msgbox, App Name hien tai(%AppName%) ko phai la devenv.exe nen nut se khong duoc bam!
return
}}
";

            string strTemp = StrAddSleepTab(strOutput, mInput);
            return strTemp;
        }

        internal string StrAltTabThenCheckAppName()
        {
            string strOutput = "";
            strOutput += "";
            strOutput += StrAddSleepTab($@"
VoidAltTab()
", new MInputMsBeginTabEnd(50,1,0));

            strOutput += $@"
{StrCheckAppName(new MInputMsBeginTabEnd(50, 1, 0))}
";

            strOutput += "";

            return strOutput;
        }

        #endregion

        #region Function common

        private string StrAddSleepTab(string strInput, MInputMsBeginTabEnd mInput)
        {
            string strOutput = "";
            strOutput += $@"
sleep, {mInput.IntMsSleepBegin}
";

            strOutput += strInput;

            strOutput += $@"
sleep, {mInput.IntMsSleepEnd}
";

            string strTemp = strOutput.Replace("\n", "\n" + StrNTab(mInput.IntSoTabMoiDong));
            return strTemp;
        }

        private string StrNTab(int intSoTabMoiDong)
        {
            string strTab = "";
            for (int i = 0; i < intSoTabMoiDong; i++)
            {
                strTab += StrOneTab;
            }
            return strTab;
        }

        #endregion

    }
}

using SWQT._640DataAccessAhk.Models;

namespace SWQT._640DataAccessAhk
{
    public class AllAhk
    {

        public List<MOneAhk> LstAhk { get; set; } = new List<MOneAhk>();

        public AllAhk()
        {
            int intIndexIncrease = 0;
            LstAhk.Add((new ListAhk.AhkVisualStudio2022.AllMultiText(++intIndexIncrease)).OAMain);
            LstAhk.Add((new ListAhk.AhkKF2.AllMultiText(++intIndexIncrease)).OAMain);
            LstAhk.Add((new ListAhk.AhkScrollToClick.AllMultiText(++intIndexIncrease)).OAMain);
            LstAhk.Add((new ListAhk.AhkSample.AllMultiText(++intIndexIncrease)).OAMain);

        }
    }
}

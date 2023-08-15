namespace SWQT._512ViewModels.Common
{
    public class RowVM
    {

        public int Stt { get; set; } = 0;

        #region 19 cell

        public CellVM C00 { get; set; } = new CellVM();

        public CellVM C01 { get; set; } = new CellVM();

        public CellVM C02 { get; set; } = new CellVM();

        public CellVM C03 { get; set; } = new CellVM();

        public CellVM C04 { get; set; } = new CellVM();

        public CellVM C05 { get; set; } = new CellVM();

        public CellVM C06 { get; set; } = new CellVM();

        public CellVM C07 { get; set; } = new CellVM();

        public CellVM C08 { get; set; } = new CellVM();

        public CellVM C09 { get; set; } = new CellVM();


        public CellVM C10 { get; set; } = new CellVM();

        public CellVM C11 { get; set; } = new CellVM();

        public CellVM C12 { get; set; } = new CellVM();

        public CellVM C13 { get; set; } = new CellVM();

        public CellVM C14 { get; set; } = new CellVM();

        public CellVM C15 { get; set; } = new CellVM();

        public CellVM C16 { get; set; } = new CellVM();

        public CellVM C17 { get; set; } = new CellVM();

        public CellVM C18 { get; set; } = new CellVM();

        public CellVM C19 { get; set; } = new CellVM();

        #endregion

        public void SetValueForCellByIndex(int intIndex, CellVM mCellInput)
        {
            switch (intIndex)
            {
                case 0:
                    C00 = mCellInput;
                    break;
                case 1:
                    C01 = mCellInput;
                    break;
                case 2:
                    C02 = mCellInput;
                    break;
                case 3:
                    C03 = mCellInput;
                    break;
                case 4:
                    C04 = mCellInput;
                    break;
                case 5:
                    C05 = mCellInput;
                    break;
                case 6:
                    C06 = mCellInput;
                    break;
                case 7:
                    C07 = mCellInput;
                    break;
                case 8:
                    C08 = mCellInput;
                    break;
                case 9:
                    C09 = mCellInput;
                    break;

                case 10:
                    C10 = mCellInput;
                    break;
                case 11:
                    C11 = mCellInput;
                    break;
                case 12:
                    C12 = mCellInput;
                    break;
                case 13:
                    C13 = mCellInput;
                    break;
                case 14:
                    C14 = mCellInput;
                    break;
                case 15:
                    C15 = mCellInput;
                    break;
                case 16:
                    C16 = mCellInput;
                    break;
                case 17:
                    C17 = mCellInput;
                    break;
                case 18:
                    C18 = mCellInput;
                    break;
                case 19:
                    C19 = mCellInput;
                    break;
                default:
                    break;
            }
        }

    }
}

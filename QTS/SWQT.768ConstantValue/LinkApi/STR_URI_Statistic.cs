namespace SWQT._768ConstantValue.LinkApi
{
    public class STR_URI_Statistic
    {
        public class nameController
        {
            public const string STR = "Statistic";
        }

        #region Thống kê đơn hàng theo thời gian viết đơn

        public class TARGetStatisticOrderByDictionary
        {
            public const string STR = "TARGetStatisticOrderByDictionary";
        }

        public class STR_URI_GET_STATISTIC_ORDER_BY_DICTIONARY
        {
            public const string STR = "/" + STR_api.name.STR + "/" + nameController.STR
                + "/" + TARGetStatisticOrderByDictionary.STR;
        }

        #endregion

    }
}

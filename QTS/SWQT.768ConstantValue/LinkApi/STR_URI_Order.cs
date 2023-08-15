namespace SWQT._768ConstantValue.LinkApi
{
    public class STR_URI_Order
    {
        public class nameController
        {
            public const string STR = "Order";
        }
        
        public class intId
        {
            public const string STR = "{intId}";
        }

        #region Phân trang danh sách đơn hàng

        public class TARGetOrderPaging
        {
            public const string STR = "TARGetOrderPaging";
        }

        public class STR_URI_ORDERPAGING
        {
            public const string STR = "/" + STR_api.name.STR + "/" + nameController.STR
                + "/" + TARGetOrderPaging.STR;
        }

        #endregion

        #region Lấy chi tiết đơn hàng

        public class TARGetDetailOrderById
        {
            public const string STR = "TARGetDetailOrderById";
        }

        public class STR_URI_DETAILORDER_BYID
        {
            public const string STR = "/" + STR_api.name.STR + "/" + nameController.STR
                + "/" + TARGetDetailOrderById.STR;
        }

        #endregion

        #region Xóa vị thuốc trong đơn hàng

        public class TARDeleteDetailOrderById
        {
            public const string STR = "TARDeleteDetailOrderById";
        }

        public class STR_TEMPLATE_API_DELETE_DETAILORDER_BYID
        {
            public const string STR = TARDeleteDetailOrderById.STR + "/" + intId.STR;
        }

        public class STR_URI_DELETE_DETAILORDER_BYID
        {
            public const string STR = "/" + STR_api.name.STR + "/" + nameController.STR
                + "/" + TARDeleteDetailOrderById.STR;
        }

        #endregion

        #region Lấy danh sách product và thông tin trong depot

        public class TARGetAllProductLeftJoinDepot
        {
            public const string STR = "TARGetAllProductLeftJoinDepot";
        }

        public class STR_URI_GETALL_PRODUCT_JOIN_DEPOT
        {
            public const string STR = "/" + STR_api.name.STR + "/" + nameController.STR
                + "/" + TARGetAllProductLeftJoinDepot.STR;
        }

        #endregion
        
        #region Lấy danh sách product theo list name, list count 0 thì trả về tất cả

        public class TARGetAllProductByListName
        {
            public const string STR = "TARGetAllProductByListName";
        }

        public class STR_URI_GETALL_PRODUCT_BY_LISTNAME
        {
            public const string STR = "/" + STR_api.name.STR + "/" + nameController.STR
                + "/" + TARGetAllProductByListName.STR;
        }

        #endregion
        
        #region Lấy dataTable id new khi insert new product

        public class TARGetDTIdNewByInsertNameProduct
        {
            public const string STR = "TARGetDTIdNewByInsertNameProduct";
        }

        public class STR_URI_GET_DT_IDNEW_BY_INSERT_NAMEPRODUCT
        {
            public const string STR = "/" + STR_api.name.STR + "/" + nameController.STR
                + "/" + TARGetDTIdNewByInsertNameProduct.STR;
        }

        #endregion
        
        #region Thêm product vào order

        public class TARAddProductToOrder
        {
            public const string STR = "TARAddProductToOrder";
        }

        public class STR_URI_ADD_PRODUCT_TO_ORDER
        {
            public const string STR = "/" + STR_api.name.STR + "/" + nameController.STR
                + "/" + TARAddProductToOrder.STR;
        }

        #endregion
        
        #region Update product ở order

        public class TARUpdateProductInOrder
        {
            public const string STR = "TARUpdateProductInOrder";
        }

        public class STR_URI_UPDATE_PRODUCT_IN_ORDER
        {
            public const string STR = "/" + STR_api.name.STR + "/" + nameController.STR
                + "/" + TARUpdateProductInOrder.STR;
        }

        #endregion

        #region Phân trang danh sách đơn hàng theo thời gian viết đơn

        public class TARGetOrderPagingByDictionary
        {
            public const string STR = "TARGetOrderPagingByDictionary";
        }

        public class STR_URI_GET_ORDER_PAGING_BY_DICTIONARY
        {
            public const string STR = "/" + STR_api.name.STR + "/" + nameController.STR
                + "/" + TARGetOrderPagingByDictionary.STR;
        }

        #endregion
        
        #region Thêm đơn hàng mới

        public class TARAddOrder
        {
            public const string STR = "TARAddOrder";
        }

        public class STR_URI_ADD_ORDER
        {
            public const string STR = "/" + STR_api.name.STR + "/" + nameController.STR
                + "/" + TARAddOrder.STR;
        }

        #endregion

    }
}

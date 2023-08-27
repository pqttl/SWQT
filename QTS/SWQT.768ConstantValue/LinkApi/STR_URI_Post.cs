namespace SWQT._768ConstantValue.LinkApi
{
    public class STR_URI_Post
    {
        public class nameController
        {
            public const string STR = "Post";
        }

        #region Thêm post

        public class TARAddPost
        {
            public const string STR = "TARAddPost";
        }

        public class STR_URI_ADD_POST
        {
            public const string STR = "/" + STR_api.name.STR + "/" + nameController.STR
                + "/" + TARAddPost.STR;
        }

        #endregion
        
        #region Cập nhật danh sách post

        public class TARUpdateListPost
        {
            public const string STR = "TARUpdateListPost";
        }

        public class STR_URI_UPDATE_LIST_POST
        {
            public const string STR = "/" + STR_api.name.STR + "/" + nameController.STR
                + "/" + TARUpdateListPost.STR;
        }

        #endregion
        
        #region Xóa post theo list id

        public class TARDeleteByListId
        {
            public const string STR = "TARDeleteByListId";
        }

        public class STR_URI_DELETEBY_LISTID
        {
            public const string STR = "/" + STR_api.name.STR + "/" + nameController.STR
                + "/" + TARDeleteByListId.STR;
        }

        #endregion

        #region Phân trang danh sách bài viết

        public class TARGetListPostPaging
        {
            public const string STR = "TARGetListPostPaging";
        }

        public class STR_URI_LISTPOSTPAGING
        {
            public const string STR = "/" + STR_api.name.STR + "/" + nameController.STR
                + "/" + TARGetListPostPaging.STR;
        }

        #endregion
        
        #region Phân trang danh sách bài viết EF Core

        public class TARGetListPostPagingNewest
        {
            public const string STR = "TARGetListPostPagingNewest";
        }

        public class STR_URI_LISTPOSTPAGING_NEWEST
        {
            public const string STR = "/" + STR_api.name.STR + "/" + nameController.STR
                + "/" + TARGetListPostPagingNewest.STR;
        }

        #endregion
        
        #region Danh sách chi tiết bài viết theo list id

        public class TARGetListDetailPostByListId
        {
            public const string STR = "TARGetListDetailPostByListId";
        }

        public class STR_URI_GETLIST_DETAILPOST_BYLISTID
        {
            public const string STR = "/" + STR_api.name.STR + "/" + nameController.STR
                + "/" + TARGetListDetailPostByListId.STR;
        }

        #endregion

    }
}

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

    }
}

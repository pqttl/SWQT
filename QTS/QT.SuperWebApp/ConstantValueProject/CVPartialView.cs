namespace QT.SuperWebApp.ConstantValueProject
{
    public class CVPartialView
    {

        public class PartialView
        {
            public const string STR = "PartialView";
            public const string PATH = "../Shared/PartialView";

            public class Home
            {
                public const string STR = "Home";
                public const string PATH = PartialView.PATH + "/" + STR;

                public class _PVIndex
                {
                    public const string STR = "_PVIndex";
                    public const string PATH = Home.PATH + "/" + STR;
                }

            }
            
            public class Ahk
            {
                public const string STR = "Ahk";
                public const string PATH = PartialView.PATH + "/" + STR;

                public class _PVOneCellDetailAhk
                {
                    public const string STR = "_PVOneCellDetailAhk";
                    public const string PATH = Ahk.PATH + "/" + STR;
                }

            }

            public class _PVListIconSvg
            {
                public const string STR = "_PVListIconSvg";
                public const string PATH = PartialView.PATH + "/" + STR;
            }
            
            public class _PVManyFuncHtml
            {
                public const string STR = "_PVManyFuncHtml";
                public const string PATH = PartialView.PATH + "/" + STR;
            }

            public class _CardSortMaxToMin
            {
                public const string STR = "_CardSortMaxToMin";
                public const string PATH = PartialView.PATH + "/" + STR;
            }

            public class _LoadingPopup
            {
                public const string STR = "_LoadingPopup";
                public const string PATH = PartialView.PATH + "/" + STR;
            }

        }

    }
}

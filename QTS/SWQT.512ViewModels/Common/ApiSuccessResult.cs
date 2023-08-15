using System.Collections.Generic;

namespace SWQT._512ViewModels.Common
{
    public class ApiSuccessResult<T> : ApiResult<T>
    {
        public ApiSuccessResult(T resultObj, Dictionary<string, object> dicInput)
        {
            BlnIsSuccessed = true;
            TResultObj = resultObj;
            DicResult = dicInput;
        }
        
        public ApiSuccessResult(T resultObj)
        {
            BlnIsSuccessed = true;
            TResultObj = resultObj;
        }

        public ApiSuccessResult<T> MHaveMessage(string strMessage, string strDetailMess = "")
        {
            BlnIsSuccessed = true;
            this.StrMessage = strMessage;
            this.StrDetailMessage = strDetailMess;
            return this;
        }

        public ApiSuccessResult()
        {
            BlnIsSuccessed = true;
        }
    }
}

using System.Collections.Generic;

namespace SWQT._512ViewModels.Common
{
    public class ApiErrorResult<T> : ApiResult<T>
    {
        public string[] ValidationErrors { get; set; }

        public ApiErrorResult()
        {
        }

        public ApiErrorResult(string strMessage)
        {
            BlnIsSuccessed = false;
            StrMessage = strMessage;
        }

        public ApiErrorResult(string[] validationErrors)
        {
            BlnIsSuccessed = false;
            ValidationErrors = validationErrors;
        }

        public ApiErrorResult<T> MHaveMessage(string strMessage, string strDetailMess = "")
        {
            this.StrMessage = strMessage;
            this.StrDetailMessage = strDetailMess;
            return this;
        }
        
        public ApiErrorResult<T> MHaveMessageWithDictionary(string strMessage, Dictionary<string, object> dicInput, string strDetailMess = "")
        {
            this.StrMessage = strMessage;
            this.StrDetailMessage = strDetailMess;
            this.DicResult = dicInput;
            return this;
        }

    }
}

using System.Collections.Generic;

namespace SWQT._512ViewModels.Common
{
    public class ApiResult<T>
    {
        public bool BlnIsSuccessed { get; set; }

        public string StrMessage { get; set; }

        public string StrDetailMessage { get; set; }

        public T TResultObj { get; set; }

        public Dictionary<string, object> DicResult { get; set; } = new Dictionary<string, object>();
    }
}

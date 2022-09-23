using Homework.Others;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework.Models
{
    public class ApiResult
    {
        private object _data;
        public object Data
        {
            get
            {
                string str = string.Empty;

                if (_data != null)
                {
                    if (_data.GetType() == typeof(string))
                    {
                        str = (string)_data;
                    }
                    else
                    {
                        str = JsonConvert.SerializeObject(_data);
                    }
                }

                return str;
            }
            set { _data = value; }
        }
        public ApiStatus Status { get; set; } = new ApiStatus();
    }

    public class ApiStatus
    {
        public ApiTypeStatus Type { get; set; } = ApiTypeStatus.Success;
        public int Code { get; set; } = 200;
        public string Message { get; set; }
        public ApiErrorCode Error { get; set; } = ApiErrorCode.None;
        public int ErrorCode { get; set; }
    }
}

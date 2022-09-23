using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework.Others
{
    /// <summary>
    /// ApiTypeStatus
    /// </summary>
    public enum ApiTypeStatus
    {
        Failure = 0,
        Success = 1
    }

    /// <summary>
    /// ApiErrorCode
    /// </summary>
    public enum ApiErrorCode
    {
        None = 0,
        InvalidParameter = 1,
        PoolNotFound = 2,
        Exception = 3,
    }
}

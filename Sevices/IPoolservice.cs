using Homework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework.Sevices
{
    public interface IPoolservice
    {
        ApiResult GetAllPool();
        ApiResult QuantileQuery(PoolQuantileParameter poolParam);
        ApiResult PoolAppend(Pool pool);
    }
}

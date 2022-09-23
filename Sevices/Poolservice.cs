using Homework.Models;
using Homework.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework.Sevices
{
    public class Poolservice : IPoolservice
    {
        /// <summary>
        /// Query Quantile
        /// </summary>
        /// <param name="poolParam"></param>
        /// <returns></returns>
        public ApiResult QuantileQuery(PoolQuantileParameter poolParam)
        {
            ApiResult apiResult = new ApiResult();
            try
            {
                //Validate param first
                if (poolParam.Percentile < 0 || poolParam.Percentile > 100)
                {
                    apiResult.Status.Error = ApiErrorCode.InvalidParameter;
                    apiResult.Status.Message = "Invalid Parameter";
                    return apiResult;
                }
                // Find pool
                Pool pool = PoolData.Pools.FirstOrDefault(x => x.PoolId == poolParam.PoolId);
                if (pool == null)
                {
                    apiResult.Status.Error = ApiErrorCode.PoolNotFound;
                    apiResult.Status.Message = "Pool Not Found";
                    return apiResult;
                }

                QuantileResult quantileResult = new QuantileResult();
                // PoolValues must be sorted before calculate
                quantileResult.Quantile = Utility.QuantileCalculate(pool.PoolValues, poolParam.Percentile/100);
                quantileResult.TotalCount = pool.PoolValues.Length;
                apiResult.Data = quantileResult;
            }
            catch (Exception)
            {
                apiResult.Status.Type = ApiTypeStatus.Failure;
                apiResult.Status.Error = ApiErrorCode.Exception;
                //TODO: log exception
            }
            return apiResult;
        }

        /// <summary>
        /// insert/ append pool to PoolData
        /// </summary>
        /// <param name="pool"></param>
        /// <returns></returns>
        public ApiResult PoolAppend(Pool pool)
        {
            ApiResult apiResult = new ApiResult();
            //Always sort ascending PoolValues 
            try
            {
                Pool poolCheck = PoolData.Pools.FirstOrDefault(x => x.PoolId == pool.PoolId);
                if (poolCheck == null)
                {
                    Utility.SortPoolValues(pool.PoolValues);
                    PoolData.Pools.Add(pool);
                    apiResult.Data = "inserted";
                }
                else
                {
                    poolCheck.PoolValues = Utility.AddRangeAndSort(poolCheck.PoolValues, pool.PoolValues);

                    apiResult.Data = "appended";
                }
            }
            catch (Exception)
            {
                apiResult.Status.Type = ApiTypeStatus.Failure;
                apiResult.Status.Error = ApiErrorCode.Exception;
                //TODO: log exception
            }
            return apiResult;
        }

        /// <summary>
        /// Get all current pool
        /// </summary>
        /// <returns></returns>
        public ApiResult GetAllPool()
        {
            ApiResult apiResult = new ApiResult();
            apiResult.Data = PoolData.Pools;
            return apiResult;
        }
    }
}

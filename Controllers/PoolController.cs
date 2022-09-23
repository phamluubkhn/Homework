using Homework.Models;
using Homework.Sevices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PoolController : Controller
    {
        private readonly IPoolservice _poolservice;
        public PoolController(IPoolservice poolservice)
        {
            _poolservice = poolservice;
        }

        /// <summary>
        /// Get all current pool
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("pools")]
        public ApiResult GetAllPool()
        {
            return _poolservice.GetAllPool();

        }

        /// <summary>
        /// PoolAppend
        /// </summary>
        /// <param name="pool"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("append")]
        public ApiResult PoolAppend(Pool pool)
        {
            return _poolservice.PoolAppend(pool);

        }

        /// <summary>
        /// QuantileQuery
        /// </summary>
        /// <param name="poolParam"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("query")]
        public ApiResult QuantileQuery(PoolQuantileParameter poolParam)
        {
            return _poolservice.QuantileQuery(poolParam);

        }
    }
}

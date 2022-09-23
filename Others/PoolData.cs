using Homework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework.Others
{
    public class PoolData
    {
        /// <summary>
        /// Pools always sorted in ascending when insert
        /// </summary>
        public static List<Pool> Pools { get; set; } = new List<Pool>
        {
            new Pool
            {
                PoolId = 1,
                PoolValues = new double[] {1, 3.6, 7.9, 9, 21.1 }
            },
            new Pool
            {
                PoolId = 7,
                PoolValues = new double[] {95.3, 234.6, 1154.8 }
            }
        };      
    }   
}

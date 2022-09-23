using Homework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework.Others
{
    public class PoolData
    {
        public static List<Pool> Pools { get; set; } = new List<Pool>
        {
            new Pool
            {
                PoolId = 1,
                PoolValues = new double[] {1, 3.6, 7.9, 9, 2.1 }
            },
            new Pool
            {
                PoolId = 7,
                PoolValues = new double[] {95.3, 2.6, 11.8 }
            }
        };      
    }   
}

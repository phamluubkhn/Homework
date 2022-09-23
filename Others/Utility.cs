using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework.Others
{
    public class Utility
    {
        /// <summary>
        /// Sorts the elements in pool value array ascending
        /// </summary>
        /// <param name="poolValues">Pool Values</param>
        public static void SortPoolValues(double[] poolValues)
        {
            int range = poolValues.Length;
            //If the pool size is less than or equal to 16 elements, it uses an insertion sort
            if (range <= 16)
            {
                InsertionSort(poolValues);
            }
            //If the number of partitions exceeds 2 * LogN, where N is the range of the input array, it uses a Heapsort.
            if (range > 2 * Math.Log10(range))
            {
                Heapsort(poolValues);
            }
            // Otherwise, use  Quicksort.
            else
            {
                QuicksortArray(poolValues, 0, poolValues.Length - 1);
            }
        }

        /// <summary>
        /// insertion sort
        /// </summary>
        /// <param name="poolValues">Pool Values</param>
        /// <returns></returns>
        public static void InsertionSort(double[] poolValues)
        {
            for (int i = 0; i < poolValues.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (poolValues[j - 1] > poolValues[j])
                    {
                        double temp = poolValues[j - 1];
                        poolValues[j - 1] = poolValues[j];
                        poolValues[j] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// Heapsort
        /// </summary>
        /// <param name="poolValues"></param>
        static void Heapsort(double[] poolValues)
        {
            int n = poolValues.Length;
            double temp;
            for (int i = n / 2; i >= 0; i--)
            {
                Heapify(poolValues, n - 1, i);
            }
            for (int i = n - 1; i >= 0; i--)
            {
                //swap last element of the max-heap with the first element
                temp = poolValues[i];
                poolValues[i] = poolValues[0];
                poolValues[0] = temp;

                //exclude the last element from the heap and rebuild the heap 
                Heapify(poolValues, i - 1, 0);
            }
        }

        /// <summary>
        /// build max heap
        /// </summary>
        /// <param name="Array"></param>
        /// <param name="n"></param>
        /// <param name="i"></param>
        public static void Heapify(double[] array, int n, int i)
        {
            int max = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            //if the left element is greater than root
            if (left <= n && array[left] > array[max])
            {
                max = left;
            }

            //if the right element is greater than root
            if (right <= n && array[right] > array[max])
            {
                max = right;
            }

            //if the max is not i
            if (max != i)
            {
                double temp = array[i];
                array[i] = array[max];
                array[max] = temp;
                //Recursively heapify the affected sub-tree
                Heapify(array, n, max);
            }
        }

        /// <summary>
        /// Quicksort Array
        /// </summary>
        /// <param name="poolValues"></param>
        /// <param name="leftIndex"></param>
        /// <param name="rightIndex"></param>
        public static void QuicksortArray(double[] poolValues, int leftIndex, int rightIndex)
        {
            var i = leftIndex;
            var j = rightIndex;
            var pivot = poolValues[leftIndex];
            while (i <= j)
            {
                while (poolValues[i] < pivot)
                {
                    i++;
                }

                while (poolValues[j] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    double temp = poolValues[i];
                    poolValues[i] = poolValues[j];
                    poolValues[j] = temp;
                    i++;
                    j--;
                }
            }

            if (leftIndex < j)
                QuicksortArray(poolValues, leftIndex, j);
            if (i < rightIndex)
                QuicksortArray(poolValues, i, rightIndex);
        }

        /// <summary>
        /// Quantile calculation
        /// </summary>
        /// <param name="poolValues"></param>
        /// <param name="quantile"></param>
        /// <returns></returns>
        public static double QuantileCalculate(double[] poolValues, double quantile)
        {
            int N = poolValues.Length;
            double n = (N - 1) * quantile + 1;
            if (n == 1d) return poolValues[0];
            else if (n == N) return poolValues[N - 1];
            else
            {
                int k = (int)n;
                double d = n - k;
                return poolValues[k - 1] + d * (poolValues[k] - poolValues[k - 1]);
            }
        }

        /// <summary>
        /// Concat two double[]
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static double[] AddRangeAndSort(double[] first, double[] second)
        {
            if (first == null)
            {
                return second;
            }
            if (second == null)
            {
                return first;
            }

            List<double> list = new List<double>(first.Length + second.Length);
            list.AddRange(first);
            list.AddRange(second);

            double[] result = list.ToArray();
            SortPoolValues(result);
            return result;
        }
    }
}

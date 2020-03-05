using System;
using System.Collections.Generic;
using System.Linq;

namespace Codility_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Program();
            //int btchid = p.solution(529);//529,20,32
            //p.SieveOfEratosthenes();
            p.solution();
        }

        public int Try()
        {
            int[] A = new int[] { 1, 1, 0, 1, 1 };
            if (A.Length == 1)
                return 0;
            var len = A.Length;
            var result = 0;

            for (int i = 0; i < len -1; i++)
            {
                if(A[i] == A[i+1])
                {
                    result++;
                }
            }

            var revers = 0;
            for (int l = 0; l < len; l++)
            {
                var count = 0;
                if(l> 0)
                {
                    count = (A[l - 1] != A[1]) ? count + 1 : count - 1;
                }
                if(l < len - 1)
                {
                    count = (A[l] != A[l+1]) ? count + 1 : count - 1;
                }
                revers = Math.Max(revers, count);
            }
            return result + revers;



        }

        public int solution()
        {
            int[] A = new int[] { 1,1,0,1,1};// { 0, 1, 1, 0 };// { 1,0,1,0,1,1};
                                                     //int noOfCOins = 0;

            //find length and starting element 
            //int cache = 0;// (A.Length >0) ?A[0] : 0;

            //for (int i = 0; i < A.Length; i++)
            //{              
            //        if(cache == A[i] && i != 0)
            //        {
            //            noOfCOins++;
            //        }
            //    cache = A[i];
            //}
            int Count = 0;
            int start = (A.Length > 0) ? A[0] : -1;
            if (start != -1)
            {
                //create your own  sequence
                int[] B = new int[A.Length];                
                bool element = false;
                for (int i = 0; i < B.Length; i++)
                {
                    if (i == 0)
                    {
                        element = Convert.ToBoolean(start);
                    }
                    else
                    {
                        element = !Convert.ToBoolean(B[i-1]);
                    }
                    B[i] = Convert.ToInt32(element);
                }
                //compare your sequence with original indexes to spot difference
                
                for (int j = 0; j < A.Length; j++)
                    {
                        if (B[j] != A[j] )
                        {
                            //NonDiv += A[j].ToString() + ',';
                            Count++;
                        }
                    }                                        
                

            }

            return Count;
        }
        public int[] SieveOfEratosthenes()
        {
            int[] A = new int[] { 3, 1, 2, 3, 6 };
            int[] B = new int[A.Length];
            //Find non-divisors
            Dictionary<int, string> dict = new Dictionary<int, string>();
            for (int i = 0; i < A.Length; i++)
            {
                //string NonDiv = string.Empty;
                int Count = 0;
                for (int j = 0; j < A.Length; j++)
                {
                    if (A[i] % A[j] != 0 && A[j] != 0)
                    {
                        //NonDiv += A[j].ToString() + ',';
                        Count++;
                    }
                }
                B[i] = Count;
                //dict.Add(A[i], NonDiv.Trim(','));
            }
            return B;

        }

        //Max Binary problem
        public int solution(int N)
        {
            string binary = Convert.ToString(N, 2).TrimEnd('0');
            string[] arr = binary.Split('1');
            string[] clearArr = arr.Where(a => a != "").Distinct().OrderBy(a => a).ToArray();
            Dictionary<int, string> dict = new Dictionary<int, string>();
            for (int i = 0; i < clearArr.Length; i++)
            {
                int k = clearArr[i].Length;
                dict.Add(k, clearArr[i]);
            }
            var p = dict.FirstOrDefault(x => x.Key == dict.Keys.Max()).Key;
            return p;
        }

        //Least Missing number in array
        public int solution(int[] A)
        {
            var i = 0;
            return A.Where(a => a > 0).Distinct().OrderBy(a => a).Any(a => a != (i = i + 1)) ? i : i + 1;
        }
    }
}

using BackendEngineer.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackendEngineer.Domain.Services
{
    public class MaximumService : IMaximumService
    {
        public int MaximumSum(int[] input)
        {
            if(input == null)
            {
                throw new InvalidOperationException("Input cannot be null.");
            }

            var startArray = 0;
            var endArray = input.Length;
            var sumArray = new List<int>();

            while(startArray <= endArray) {
              
                sumArray.AddRange(SumAllSubArrays(input, startArray, endArray));

                startArray++;
            }
            return sumArray.Max();
        }

        public IEnumerable<int> SumAllSubArrays(int[] array, int startArray, int endArray)
        {
            for (var numbers = startArray + 1; numbers <= endArray; numbers++)
            {
                yield return array.Skip(startArray).Take(numbers).Sum();
            }
        }
    }
}

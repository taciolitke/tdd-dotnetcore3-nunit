using BackendEngineer.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BackendEngineer.Domain.Services
{
    public class MinimumStartService : IMinimumStartService
    {
        public const int MinimumValue = 1;

        public int MinimumStart(int[] input)
        {
            if (input == null)
            {
                throw new InvalidOperationException("Input cannot be null.");
            }

            var minimumStart = input.Min();

            var existsInvalidSum = true;

            IEnumerable<int> result;

            while (existsInvalidSum)
            {
                result = SumArray(minimumStart, input);

                existsInvalidSum = result.Any(number => number < MinimumValue);

                if (existsInvalidSum)
                {
                    minimumStart++;
                }
            }

            return minimumStart;
        }

        private IEnumerable<int> SumArray(int startNumber, int[] input)
        {
            var total = startNumber;
            var totalList = new List<int>();

            foreach (var number in input)
            {
                total += number;

                totalList.Add(total);

                if (total < MinimumValue)
                {
                    break;
                }
            }
            return totalList;
        }
    }
}

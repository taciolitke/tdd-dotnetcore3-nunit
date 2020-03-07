using BackendEngineer.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BackendEngineer.Domain.Services
{
    public class TicketService : ITicketService
    {
        public int MaxSequence(int[] input)
        {
            if (input == null)
            {
                throw new InvalidOperationException("Input cannot be null.");
            }

            var sequence = input.OrderBy(number => number).ToList();
            var currentList = new List<int>();
            var subSequences = new List<IEnumerable<int>>();

            for (var currentPosition = 0; currentPosition < sequence.Count; currentPosition++)
            {
                currentList.Add(sequence[currentPosition]);
                if (IsNewSequence(currentPosition, sequence))
                {
                    subSequences.Add(currentList);
                    currentList = new List<int>();
                }
            }
            subSequences.Add(currentList);

            return subSequences.Max(x => x.Count());
        }

        private bool IsNewSequence(int currentPosition, List<int> sequence)
        {
            var nextPosition = currentPosition + 1;
            var nextIncrementValue = sequence[currentPosition] + 1;

            var result = nextPosition != sequence.Count && sequence[nextPosition] > nextIncrementValue;

            return result;
        }
    }
}

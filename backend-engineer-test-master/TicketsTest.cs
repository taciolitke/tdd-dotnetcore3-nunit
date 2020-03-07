using BackendEngineer.Domain.Interfaces;
using BackendEngineer.Domain.Services;
using NUnit.Framework;
using System;
using System.Linq;

namespace BackendEngineer
{
    /**
      Consider an array of n ticket prices, tickets.
      A number, m, is defined as the size of some subsequence, s, of tickets where each element covers an unbroken range of integers.
      
      That is to say, if you were to sort the elements in s,
        the absolute difference between any elements j and j + 1 would be either 0 or 1.
      
      For example, tickets = [8, 5, 4, 8, 4] gives us sorted subsequences {4, 4, 5} and {8, 8};
         these subsequences have m values of 3 and 2, respectively.

     Complete the function MaxSequence below. 
        The function must return an integer that denotes the maximum possible value of m.

        MaxSequence has the following parameter(s):
            tickets[tickets[0],...tickets[n-1]]:  an array of integers

        Constraints
        1 ≤ n ≤ 1000000
        1 ≤ tickets[i] ≤ 100000000
     */
    public class TicketsTest
    {
        private ITicketService _ticketService;

        [SetUp]
        public void Setup()
        {
            _ticketService = new TicketService();
        }

        // There are three subsequences of tickets that contain consecutive integers: {1}, {3} and {5}.
        // These subsequences have m values of 1, 1 and 1, respectively. Return the maximum value of m, which is 1.
        [Test]
        public void MaxSequence_Sample1()
        {
            var input = new[] {1, 3, 5};
            var output = _ticketService.MaxSequence(input);
            Assert.AreEqual(1, output);
        }

        // There are two subsequences of tickets that contain consecutive integers: {2, 3, 4} and {13}.
        // These subsequences have m values of 3 and 1, respectively. Return the maximum value of m, which is 3.
        [Test]
        public void MaxSequence_Sample2()
        {
            var input = new[] {4, 13, 2, 3};
            var output = _ticketService.MaxSequence(input);
            Assert.AreEqual(3, output);
        }

        // There are two subsequences of tickets that contain consecutive integers: {4, 4, 5} and {8, 8}.
        // These subsequences have m values of 3 and 2, respectively. Return the maximum value of m, which is 3.
        [Test]
        public void MaxSequence_Sample3()
        {
            var input = new[] {8, 5, 4, 8, 4};
            var output = _ticketService.MaxSequence(input);
            Assert.AreEqual(3, output);
        }

        [Test]
        public void MaxSequence_Sample4()
        {
            var input = new[] {5, 4, 3, 2, 1, 8, 8, 8, 9};
            var output = _ticketService.MaxSequence(input);
            Assert.AreEqual(5, output);
        }

        [Test]
        public void MaxSequence_Sample5()
        {
            var input = new[] {1, 1, 1, 2, 3, 5, 5, 6, 8};
            var output = _ticketService.MaxSequence(input);
            Assert.AreEqual(5, output);
        }

        [Test]
        public void MaxSequence_Exception()
        {
            Assert.Throws<InvalidOperationException>(() => _ticketService.MaxSequence(null));
        }
    }
}
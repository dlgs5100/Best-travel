using System;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace Best_travel
{
    [TestFixture]
    public class SumOfKTests
    {
        [Test]
        public void Test1()
        {
            Console.WriteLine("****** Basic Tests");
            List<int> ts = new List<int> { 50, 55, 56, 57, 58 };
            int? n = SumOfK.chooseBestSum(163, 3, ts);
            Assert.AreEqual(163, n);

            ts = new List<int> { 50 };
            n = SumOfK.chooseBestSum(163, 3, ts);
            Assert.AreEqual(null, n);

            ts = new List<int> { 91, 74, 73, 85, 73, 81, 87 };
            n = SumOfK.chooseBestSum(230, 3, ts);
            Assert.AreEqual(228, n);
        }
    }
    public static class SumOfK
    {
        //Reference by : https://stackoverflow.com/questions/127704/algorithm-to-return-all-combinations-of-k-elements-from-n
        public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> elements, int k)
        {
            return k == 0 ? new[] { new T[0] } :
              elements.SelectMany((e, i) =>
                elements.Skip(i + 1).Combinations(k - 1).Select(c => (new[] { e }).Concat(c)));
        }
        public static int? chooseBestSum(int maxDistance, int amountCountry, List<int> ts)
        {
            var result = Combinations(ts, amountCountry).ToList();
            result.RemoveAll(n => n.ToList().Sum() > maxDistance);
            if (!result.Any())
                return null;
            else
                return result.Select(m => m.Sum()).Max();
        }
    }
}

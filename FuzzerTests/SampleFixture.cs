using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Fuzzer;

namespace FuzzerTests
{
    [TestFixture]
    public class SampleFixture
    {
        [Test]
        [TestCaseSource("SampleTestGenerator")]
        public void SampleTest(string name, double lattitude, double longitude, DateTime when)
        {
            // Your assertions go here
            Assert.True(true);
        }

        public static IEnumerable<TestCaseData> SampleTestGenerator()
        {
            Scenario scenario = new Scenario()
                .NonRandom()
                .Random(amount: 10);

            return new CasesGenerator<string, double, double, DateTime>(scenario)
                .Select(c => new TestCaseData(c));
        }
    }
}

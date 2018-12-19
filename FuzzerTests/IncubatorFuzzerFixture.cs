using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Fuzzer;
using Fuzzer.Fuzzers;

namespace FuzzerTests
{
    [TestFixture]
    public class IncubatorFuzzerFixture
    {
        [Test]
        [TestCaseSource("SampleIncubatorFuzzerTestGenerator")]
        public void SampleIncubatorFuzzerTest(DBNull value)
        {
            // Your assertions go here
            Assert.True(true);
        }

        public static IEnumerable<TestCaseData> SampleIncubatorFuzzerTestGenerator()
        {
            Scenario scenario = new Scenario()
                .Custom(IncubatorFuzzer.Create(() => DBNull.Value));

            return new CasesGenerator<DBNull>(scenario)
                .Select(c => new TestCaseData(c));
        }
    }
}

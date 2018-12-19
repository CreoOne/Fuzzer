using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Fuzzer;
using Fuzzer.Fuzzers;

namespace FuzzerTests
{
    [TestFixture]
    public class CustomFuzzerFixture
    {
        [Test]
        [TestCaseSource("SampleCustomFuzzerTestGenerator")]
        public void SampleCustomFuzzerTest(DBNull value)
        {
            // Your assertions go here
            Assert.True(true);
        }

        public static IEnumerable<TestCaseData> SampleCustomFuzzerTestGenerator()
        {
            Scenario scenario = new Scenario()
                .Custom(new DBNullFuzzer());

            return new CasesGenerator<DBNull>(scenario)
                .Select(c => new TestCaseData(c));
        }
    }

    internal class DBNullFuzzer : IFuzzer<DBNull>
    {
        public DBNull Provide()
        {
            return DBNull.Value;
        }
    }
}

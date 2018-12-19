using Fuzzer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuzzerExp
{
    class Program
    {
        static void Main(string[] args)
        {
            Scenario scenario = new Scenario()
                .NonRandom()
                .Random(amount: 10)
                .RandomString(amount: 10, encoding: Encoding.UTF8)
                .RandomDateTime(amount: 10, kind: DateTimeKind.Utc)
                .Except(1UL)
                .Except(default(DateTime))
                .Except(default(Guid));

            IEnumerable<object[]> results = new CasesGenerator<float, string, DateTime, Guid>(scenario);
        }
    }
}

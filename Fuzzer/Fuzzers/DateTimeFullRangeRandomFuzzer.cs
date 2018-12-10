using System;
using System.Security.Cryptography;

namespace Fuzzer.Fuzzers
{
    public class DateTimeFullRangeRandomFuzzer : FullRangeRandomFuzzerAbstract<DateTime>
    {
        private DateTimeKind Kind;

        public DateTimeFullRangeRandomFuzzer(RandomNumberGenerator randomNumberGenerator, DateTimeKind kind) : base(randomNumberGenerator)
        {
            Kind = kind;
        }

        public override DateTime Provide()
        {
            long ticks = (long)GenerateRandomDoubleInRange(DateTime.MinValue.Ticks, DateTime.MaxValue.Ticks);

            return new DateTime(ticks, Kind);
        }
    }
}

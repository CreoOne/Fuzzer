using System;
using System.Security.Cryptography;

namespace Fuzzer.Fuzzers
{
    public class DoubleFullRangeRandomFuzzer : FullRangeRandomFuzzerAbstract<double>
    {
        public DoubleFullRangeRandomFuzzer(RandomNumberGenerator randomNumberGenerator) : base(randomNumberGenerator) { }

        public override double Provide()
        {
            byte[] bytes = new byte[sizeof(double)];
            RandomNumberGenerator.GetBytes(bytes);
            return BitConverter.ToDouble(bytes, 0);
        }
    }
}

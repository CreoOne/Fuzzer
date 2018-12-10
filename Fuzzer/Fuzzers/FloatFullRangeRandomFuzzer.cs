using System;
using System.Security.Cryptography;

namespace Fuzzer.Fuzzers
{
    public class FloatFullRangeRandomFuzzer : FullRangeRandomFuzzerAbstract<float>
    {
        public FloatFullRangeRandomFuzzer(RandomNumberGenerator randomNumberGenerator) : base(randomNumberGenerator) { }

        public override float Provide()
        {
            byte[] bytes = new byte[4];
            RandomNumberGenerator.GetBytes(bytes);
            return BitConverter.ToSingle(bytes, 0);
        }
    }
}

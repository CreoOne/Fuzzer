using System.Security.Cryptography;

namespace Fuzzer.Fuzzers
{
    public class BooleanFullRangeRandomFuzzer : FullRangeRandomFuzzerAbstract<bool>
    {
        public BooleanFullRangeRandomFuzzer(RandomNumberGenerator randomNumberGenerator) : base(randomNumberGenerator) { }

        public override bool Provide()
        {
            byte[] b = new byte[1];
            RandomNumberGenerator.GetBytes(b);
            return b[0] > 127;
        }
    }
}

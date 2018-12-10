using System.Security.Cryptography;

namespace Fuzzer.Fuzzers
{
    public class ByteFullRangeRandomFuzzer : FullRangeRandomFuzzerAbstract<byte>
    {
        public ByteFullRangeRandomFuzzer(RandomNumberGenerator randomNumberGenerator) : base(randomNumberGenerator) { }

        public override byte Provide()
        {
            byte[] b = new byte[1];
            RandomNumberGenerator.GetBytes(b);
            return b[0];
        }
    }
}

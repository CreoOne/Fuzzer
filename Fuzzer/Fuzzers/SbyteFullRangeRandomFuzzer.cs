using System.Security.Cryptography;

namespace Fuzzer.Fuzzers
{
    public class SbyteFullRangeRandomFuzzer : FullRangeRandomFuzzerAbstract<sbyte>
    {
        ByteFullRangeRandomFuzzer ByteFullRangeRandomFuzzer;

        public SbyteFullRangeRandomFuzzer(RandomNumberGenerator randomNumberGenerator) : base(randomNumberGenerator)
        {
            ByteFullRangeRandomFuzzer = new ByteFullRangeRandomFuzzer(randomNumberGenerator);
        }

        public override sbyte Provide()
        {
            return unchecked((sbyte)ByteFullRangeRandomFuzzer.Provide());
        }
    }
}

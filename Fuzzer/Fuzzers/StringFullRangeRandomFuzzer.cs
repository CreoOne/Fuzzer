using System;
using System.Security.Cryptography;
using System.Text;

namespace Fuzzer.Fuzzers
{
    public class StringFullRangeRandomFuzzer : FullRangeRandomFuzzerAbstract<string>
    {
        private Encoding Encoding;

        public StringFullRangeRandomFuzzer(RandomNumberGenerator randomNumberGenerator, Encoding encoding) : base(randomNumberGenerator)
        {
            Encoding = encoding;
        }

        public override string Provide()
        {
            byte[] lengthBytes = new byte[sizeof(ushort)];
            RandomNumberGenerator.GetBytes(lengthBytes);
            ushort length = BitConverter.ToUInt16(lengthBytes, 0);
            byte[] stringBytes = new byte[length];
            RandomNumberGenerator.GetBytes(stringBytes);
            return Encoding.GetString(stringBytes);
        }
    }
}

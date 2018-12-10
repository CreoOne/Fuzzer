using System;
using System.Security.Cryptography;

namespace Fuzzer.Fuzzers
{
    public abstract class FullRangeRandomFuzzerAbstract<TResult> : IFuzzer<TResult>
    {
        protected RandomNumberGenerator RandomNumberGenerator;

        public FullRangeRandomFuzzerAbstract(RandomNumberGenerator randomNumberGenerator)
        {
            RandomNumberGenerator = randomNumberGenerator ?? throw new ArgumentNullException(nameof(randomNumberGenerator));
        }

        public abstract TResult Provide();

        protected double GenerateRandomDoubleInRange(double minValue, double maxValue)
        {
            byte[] bytes = new byte[sizeof(uint)];
            RandomNumberGenerator.GetBytes(bytes);
            uint randomValue = BitConverter.ToUInt32(bytes, 0);

            return (randomValue / (double)UInt32.MaxValue) * (maxValue - minValue) + minValue;
        }
    }
}

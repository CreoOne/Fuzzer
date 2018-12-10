using Fuzzer.Fuzzers;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Fuzzer
{
    public class Scenario
    {
        public readonly FuzzersCollection Fuzzers = new FuzzersCollection();

        public Scenario NonRandom()
        {
            Booleans();
            Bytes();
            Sbytes();
            Shorts();
            Ushorts();
            Ints();
            Uints();
            Longs();
            Ulongs();
            Floats();
            Doubles();
            Decimals();
            Strings();
            DateTimes();
            Guids();

            return this;
        }

        private Scenario Booleans()
        {
            Fuzzers
                .Add(ConstantFuzzer.Create(true))
                .Add(ConstantFuzzer.Create(false));

            return this;
        }

        private Scenario Bytes()
        {
            Fuzzers
                .Add(ConstantFuzzer.Create(byte.MinValue))
                .Add(ConstantFuzzer.Create(byte.MaxValue))
                .Add(ConstantFuzzer.Create<byte>(1));

            return this;
        }

        private Scenario Sbytes()
        {
            Fuzzers
                .Add(ConstantFuzzer.Create(sbyte.MinValue))
                .Add(ConstantFuzzer.Create(sbyte.MaxValue))
                .Add(ConstantFuzzer.Create<sbyte>(-1))
                .Add(ConstantFuzzer.Create<sbyte>(1));

            return this;
        }

        private Scenario Shorts()
        {
            Fuzzers
                .Add(ConstantFuzzer.Create(short.MinValue))
                .Add(ConstantFuzzer.Create(short.MaxValue))
                .Add(ConstantFuzzer.Create<short>(-1))
                .Add(ConstantFuzzer.Create<short>(1));

            return this;
        }

        private Scenario Ushorts()
        {
            Fuzzers
                .Add(ConstantFuzzer.Create(ushort.MinValue))
                .Add(ConstantFuzzer.Create(ushort.MaxValue))
                .Add(ConstantFuzzer.Create<ushort>(1));

            return this;
        }

        private Scenario Ints()
        {
            Fuzzers
                .Add(ConstantFuzzer.Create(int.MinValue))
                .Add(ConstantFuzzer.Create(int.MaxValue))
                .Add(ConstantFuzzer.Create<int>(-1))
                .Add(ConstantFuzzer.Create<int>(1));

            return this;
        }

        private Scenario Uints()
        {
            Fuzzers
                .Add(ConstantFuzzer.Create(uint.MinValue))
                .Add(ConstantFuzzer.Create(uint.MaxValue))
                .Add(ConstantFuzzer.Create<uint>(1));

            return this;
        }

        private Scenario Longs()
        {
            Fuzzers
                .Add(ConstantFuzzer.Create(long.MinValue))
                .Add(ConstantFuzzer.Create(long.MaxValue))
                .Add(ConstantFuzzer.Create<long>(-1))
                .Add(ConstantFuzzer.Create<long>(1));

            return this;
        }

        private Scenario Ulongs()
        {
            Fuzzers
                .Add(ConstantFuzzer.Create(ulong.MinValue))
                .Add(ConstantFuzzer.Create(ulong.MaxValue))
                .Add(ConstantFuzzer.Create<ulong>(1));

            return this;
        }

        private Scenario Floats()
        {
            Fuzzers
                .Add(ConstantFuzzer.Create(float.NegativeInfinity))
                .Add(ConstantFuzzer.Create(float.PositiveInfinity))
                .Add(ConstantFuzzer.Create(float.MinValue))
                .Add(ConstantFuzzer.Create(float.MaxValue))
                .Add(ConstantFuzzer.Create(-1f))
                .Add(ConstantFuzzer.Create(1f))
                .Add(ConstantFuzzer.Create(float.NaN))
                .Add(ConstantFuzzer.Create(float.Epsilon));

            return this;
        }

        private Scenario Doubles()
        {
            Fuzzers
                .Add(ConstantFuzzer.Create(double.NegativeInfinity))
                .Add(ConstantFuzzer.Create(double.PositiveInfinity))
                .Add(ConstantFuzzer.Create(double.MinValue))
                .Add(ConstantFuzzer.Create(double.MaxValue))
                .Add(ConstantFuzzer.Create(-1d))
                .Add(ConstantFuzzer.Create(1d))
                .Add(ConstantFuzzer.Create(double.NaN))
                .Add(ConstantFuzzer.Create(double.Epsilon));

            return this;
        }

        private Scenario Decimals()
        {
            Fuzzers
                .Add(ConstantFuzzer.Create(decimal.MinValue))
                .Add(ConstantFuzzer.Create(decimal.MaxValue))
                .Add(ConstantFuzzer.Create(-1m))
                .Add(ConstantFuzzer.Create(1m));

            return this;
        }

        private Scenario Strings()
        {
            Fuzzers
                .Add(ConstantFuzzer.Create(string.Empty))
                .Add(ConstantFuzzer.Create("\0"))
                .Add(ConstantFuzzer.Create("\r\n"))
                .Add(ConstantFuzzer.Create("\r"))
                .Add(ConstantFuzzer.Create("\n"))
                .Add(ConstantFuzzer.Create("/\\//\""));

            return this;
        }

        private Scenario DateTimes()
        {
            Fuzzers
                .Add(ConstantFuzzer.Create(DateTime.MinValue))
                .Add(ConstantFuzzer.Create(DateTime.MaxValue))
                .Add(ConstantFuzzer.Create(DateTime.Now));

            return this;
        }

        private Scenario Guids()
        {
            Fuzzers
                .Add(ConstantFuzzer.Create(Guid.Empty))
                .Add(ConstantFuzzer.Create(new Guid(Enumerable.Repeat((byte)255, 16).ToArray()))); // MaxValue

            return this;
        }

        public Scenario Random(int amount)
        {
            RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();

            foreach (int i in Enumerable.Range(0, amount))
                Fuzzers
                    .Add(new BooleanFullRangeRandomFuzzer(randomNumberGenerator))
                    .Add(new ByteFullRangeRandomFuzzer(randomNumberGenerator))
                    .Add(new SbyteFullRangeRandomFuzzer(randomNumberGenerator))
                    .Add(new FloatFullRangeRandomFuzzer(randomNumberGenerator))
                    .Add(new DoubleFullRangeRandomFuzzer(randomNumberGenerator))  
                    .Add(new GuidFullRangeRandomFuzzer());

            return this;
        }

        public Scenario RandomString(int amount, Encoding encoding)
        {
            RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();

            foreach (int i in Enumerable.Range(0, amount))
                Fuzzers.Add(new StringFullRangeRandomFuzzer(randomNumberGenerator, encoding));

            return this;
        }

        public Scenario RandomDateTime(int amount, DateTimeKind kind)
        {
            RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();

            foreach (int i in Enumerable.Range(0, amount))
                Fuzzers.Add(new DateTimeFullRangeRandomFuzzer(randomNumberGenerator, kind));

            return this;
        }

        public Scenario Custom(IFuzzer fuzzer)
        {
            Fuzzers.Add(fuzzer);

            return this;
        }

        public Scenario Except<T>(T value)
        {
            Fuzzers.Except(value);

            return this;
        }
    }
}

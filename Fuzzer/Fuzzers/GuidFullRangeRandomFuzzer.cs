using System;

namespace Fuzzer.Fuzzers
{
    public class GuidFullRangeRandomFuzzer : IFuzzer<Guid>
    {
        public Guid Provide()
        {
            return Guid.NewGuid();
        }
    }
}

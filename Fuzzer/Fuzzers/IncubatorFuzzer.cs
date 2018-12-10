using System;

namespace Fuzzer.Fuzzers
{
    public static class IncubatorFuzzer
    {
        public static IncubatorFuzzer<T> Create<T>(Func<T> incubator) => new IncubatorFuzzer<T>(incubator);
    }

    public class IncubatorFuzzer<TResult> : IFuzzer<TResult>
    {
        private Func<TResult> Incubator;

        public IncubatorFuzzer(Func<TResult> incubator)
        {
            Incubator = incubator ?? throw new ArgumentNullException(nameof(incubator));
        }

        public TResult Provide()
        {
            return Incubator();
        }
    }
}

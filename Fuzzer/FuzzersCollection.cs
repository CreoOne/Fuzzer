using Fuzzer.Fuzzers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fuzzer
{
    public class FuzzersCollection
    {
        private HashSet<IFuzzer> Fuzzers;
        private HashSet<object> Exclusions;

        public FuzzersCollection()
        {
            Fuzzers = new HashSet<IFuzzer>();
            Exclusions = new HashSet<object>();
        }

        public FuzzersCollection(IEnumerable<IFuzzer> fuzzers, IEnumerable<object> exclusions = null)
        {
            Fuzzers = new HashSet<IFuzzer>(fuzzers) ?? throw new ArgumentNullException(nameof(fuzzers));
            Exclusions = new HashSet<object>(exclusions ?? Enumerable.Empty<object>());
        }

        public FuzzersCollection Add(IFuzzer fuzzer)
        {
            Fuzzers.Add(fuzzer);

            return this;
        }

        public FuzzersCollection Except<T>(T value)
        {
            Exclusions.Add(value);

            return this;
        }

        public IEnumerable<TResult> Provide<TResult>()
        {
            IEnumerable<TResult> exclusions = Exclusions
                .Where(e => e is TResult || (default(TResult) == null) && (e == null))
                .Cast<TResult>();

            return Fuzzers
                .OfType<IFuzzer<TResult>>()
                .Select(f => f.Provide())
                .Concat(YieldReturn(default(TResult)))
                .Distinct()
                .Except(exclusions);
        }

        private static IEnumerable<T> YieldReturn<T>(T t)
        {
            yield return t;
        }
    }
}

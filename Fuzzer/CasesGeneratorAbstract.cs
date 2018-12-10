using System;
using System.Collections;
using System.Collections.Generic;

namespace Fuzzer
{
    public abstract class CasesGeneratorAbstract : IEnumerable<object[]>
    {
        protected Scenario Scenario;

        public CasesGeneratorAbstract(Scenario scenario)
        {
            Scenario = scenario ?? throw new ArgumentNullException(nameof(scenario));
        }

        public abstract IEnumerator<object[]> GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

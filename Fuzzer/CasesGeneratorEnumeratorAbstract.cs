using System;
using System.Collections;
using System.Linq;

namespace Fuzzer
{
    public class CasesGeneratorEnumeratorAbstract
    {
        protected IEnumerator[] Enumerators = new IEnumerator[0];

        protected void RegisterEnumerators(params IEnumerator[] enumerators)
        {
            Enumerators = enumerators ?? throw new ArgumentNullException(nameof(enumerators));
        }

        public bool MoveNext()
        {
            foreach (IEnumerator enumerator in Enumerators)
            {
                if (enumerator.MoveNext())
                    return true;

                enumerator.Reset();
            }

            return false;
        }

        public void Reset()
        {
            foreach (IEnumerator enumerator in Enumerators)
                enumerator.Reset();

            foreach (IEnumerator enumerator in Enumerators.Skip(1))
                enumerator.MoveNext();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Fuzzer
{
    public class CasesGeneratorEnumerator<T1>
        : CasesGeneratorEnumeratorAbstract, IEnumerator<object[]>
    {
        private IEnumerator<T1> Enumerator1;

        object IEnumerator.Current => Current;
        public object[] Current => new object[]
        {
            Enumerator1.Current
        };

        public CasesGeneratorEnumerator(IEnumerable<T1> e1)
        {
            Enumerator1 = e1.ToList().GetEnumerator();

            RegisterEnumerators(Enumerator1);

            Reset();
        }

        public void Dispose()
        {
            Enumerator1.Dispose();
        }
    }

    public class CasesGeneratorEnumerator<T1, T2>
        : CasesGeneratorEnumeratorAbstract, IEnumerator<object[]>
    {
        private IEnumerator<T1> Enumerator1;
        private IEnumerator<T2> Enumerator2;

        object IEnumerator.Current => Current;
        public object[] Current => new object[]
        {
            Enumerator1.Current,
            Enumerator2.Current
        };

        public CasesGeneratorEnumerator(IEnumerable<T1> e1, IEnumerable<T2> e2)
        {
            Enumerator1 = e1.ToList().GetEnumerator();
            Enumerator2 = e2.ToList().GetEnumerator();

            RegisterEnumerators(
                Enumerator1,
                Enumerator2
            );

            Reset();
        }

        public void Dispose()
        {
            Enumerator1.Dispose();
            Enumerator2.Dispose();
        }
    }

    public class CasesGeneratorEnumerator<T1, T2, T3>
        : CasesGeneratorEnumeratorAbstract, IEnumerator<object[]>
    {
        private IEnumerator<T1> Enumerator1;
        private IEnumerator<T2> Enumerator2;
        private IEnumerator<T3> Enumerator3;

        object IEnumerator.Current => Current;
        public object[] Current => new object[]
        {
            Enumerator1.Current,
            Enumerator2.Current,
            Enumerator3.Current
        };

        public CasesGeneratorEnumerator(IEnumerable<T1> e1, IEnumerable<T2> e2, IEnumerable<T3> e3)
        {
            Enumerator1 = e1.ToList().GetEnumerator();
            Enumerator2 = e2.ToList().GetEnumerator();
            Enumerator3 = e3.ToList().GetEnumerator();

            RegisterEnumerators(
                Enumerator1,
                Enumerator2,
                Enumerator3
            );

            Reset();
        }

        public void Dispose()
        {
            Enumerator1.Dispose();
            Enumerator2.Dispose();
            Enumerator3.Dispose();
        }
    }

    public class CasesGeneratorEnumerator<T1, T2, T3, T4>
        : CasesGeneratorEnumeratorAbstract, IEnumerator<object[]>
    {
        private IEnumerator<T1> Enumerator1;
        private IEnumerator<T2> Enumerator2;
        private IEnumerator<T3> Enumerator3;
        private IEnumerator<T4> Enumerator4;

        object IEnumerator.Current => Current;
        public object[] Current => new object[]
        {
            Enumerator1.Current,
            Enumerator2.Current,
            Enumerator3.Current,
            Enumerator4.Current
        };

        public CasesGeneratorEnumerator(IEnumerable<T1> e1, IEnumerable<T2> e2, IEnumerable<T3> e3, IEnumerable<T4> e4)
        {
            Enumerator1 = e1.ToList().GetEnumerator();
            Enumerator2 = e2.ToList().GetEnumerator();
            Enumerator3 = e3.ToList().GetEnumerator();
            Enumerator4 = e4.ToList().GetEnumerator();

            RegisterEnumerators(
                Enumerator1,
                Enumerator2,
                Enumerator3, 
                Enumerator4
            );

            Reset();
        }

        public void Dispose()
        {
            Enumerator1.Dispose();
            Enumerator2.Dispose();
            Enumerator3.Dispose();
            Enumerator4.Dispose();
        }
    }
}

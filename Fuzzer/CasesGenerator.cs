using Fuzzer.Generators;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Fuzzer
{
    public static class CasesGenerator
    {
        public static IEnumerable<object[]> Create(Scenario scenario, params Type[] types)
        {
            if (types == null)
                throw new ArgumentNullException(nameof(types));

            switch (types.Length)
            {
                case 0: throw new ArgumentException("Case generator needs at least one type to operate.");
                case 1: return CreateInstance(scenario, typeof(CasesGenerator<>), types);
                case 2: return CreateInstance(scenario, typeof(CasesGenerator<,>), types);
                case 3: return CreateInstance(scenario, typeof(CasesGenerator<,,>), types);
                case 4: return CreateInstance(scenario, typeof(CasesGenerator<,,,>), types);
                default: return CasesGeneratorAssembler.Assemble(scenario, types);
            }

            throw new NotImplementedException();
        }

        private static IEnumerable<object[]> CreateInstance(Scenario scenario, Type casesGeneratorType, params Type[] types)
        {
            Type constructedType = casesGeneratorType.MakeGenericType(types);
            object[] constructorParameters = new object[] { scenario };

            return Activator.CreateInstance(constructedType, constructorParameters) as IEnumerable<object[]>;
        }
    }

    public class CasesGenerator<T1>
        : CasesGeneratorAbstract, IEnumerable<object[]>
    {
        public CasesGenerator(Scenario scenario) : base(scenario) { }

        public override IEnumerator<object[]> GetEnumerator()
        {
            IEnumerable<T1> p1 = Scenario.Fuzzers.Provide<T1>();

            return new CasesGeneratorEnumerator<T1>(p1);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class CasesGenerator<T1, T2>
        : CasesGeneratorAbstract, IEnumerable<object[]>
    {
        public CasesGenerator(Scenario scenario) : base(scenario) { }

        public override IEnumerator<object[]> GetEnumerator()
        {
            IEnumerable<T1> p1 = Scenario.Fuzzers.Provide<T1>();
            IEnumerable<T2> p2 = Scenario.Fuzzers.Provide<T2>();

            return new CasesGeneratorEnumerator<T1, T2>(p1, p2);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class CasesGenerator<T1, T2, T3>
        : CasesGeneratorAbstract, IEnumerable<object[]>
    {
        public CasesGenerator(Scenario scenario) : base(scenario) { }

        public override IEnumerator<object[]> GetEnumerator()
        {
            IEnumerable<T1> p1 = Scenario.Fuzzers.Provide<T1>();
            IEnumerable<T2> p2 = Scenario.Fuzzers.Provide<T2>();
            IEnumerable<T3> p3 = Scenario.Fuzzers.Provide<T3>();

            return new CasesGeneratorEnumerator<T1, T2, T3>(p1, p2, p3);
        }
    }

    public class CasesGenerator<T1, T2, T3, T4>
        : CasesGeneratorAbstract, IEnumerable<object[]>
    {
        public CasesGenerator(Scenario scenario) : base(scenario) { }

        public override IEnumerator<object[]> GetEnumerator()
        {
            IEnumerable<T1> p1 = Scenario.Fuzzers.Provide<T1>();
            IEnumerable<T2> p2 = Scenario.Fuzzers.Provide<T2>();
            IEnumerable<T3> p3 = Scenario.Fuzzers.Provide<T3>();
            IEnumerable<T4> p4 = Scenario.Fuzzers.Provide<T4>();

            return new CasesGeneratorEnumerator<T1, T2, T3, T4>(p1, p2, p3, p4);
        }
    }
}

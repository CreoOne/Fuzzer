namespace Fuzzer.Fuzzers
{
    public static class ConstantFuzzer
    {
        public static ConstantFuzzer<T> Create<T>(T value) => new ConstantFuzzer<T>(value);
    }

    public class ConstantFuzzer<TResult> : IFuzzer<TResult>
    {
        private TResult Value;

        public ConstantFuzzer(TResult value)
        {
            Value = value;
        }

        public TResult Provide()
        {
            return Value;
        }

    }
}

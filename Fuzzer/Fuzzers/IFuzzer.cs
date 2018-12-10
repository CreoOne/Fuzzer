namespace Fuzzer.Fuzzers
{
    public interface IFuzzer { }

    public interface IFuzzer<TFuzzType> : IFuzzer
    {
        TFuzzType Provide();
    }
}

# Fuzzer
Helping hand in testing.

## Description
Fuzzer is a simple cases generator for unit tests. It brute-forces trough all possible combinations of provided values. It works with frequent values like `0` or `1` but can also do fuzzing with `NaN` and random strings that are megabytes in size.

## Roadmap
For current roadmap go to [General Project](./../../projects/1)

## Usage
```cs
Scenario scenario = new Scenario()
  .NonRandom()
  .Random(amount: 10)
  .RandomString(amount: 10, encoding: Encoding.UTF8)
  .RandomDateTime(amount: 10, kind: DateTimeKind.Utc)
  .Except(1UL)
  .Except(default(DateTime))
  .Except(default(Guid));

IEnumerable<object[]> results = new CasesGenerator<float, string, DateTime, Guid>(scenario);
```
### with NUnit
like in [SampleFixture.cs](./FuzzerTests/SampleFixture.cs)
```cs
    [TestFixture]
    public class SampleFixture
    {
        [Test]
        [TestCaseSource("SampleTestGenerator")]
        public void SampleTest(string name, double lattitude, double longitude, DateTime when)
        {
            // Your assertions go here
            Assert.True(true);
        }

        public static IEnumerable<TestCaseData> SampleTestGenerator()
        {
            Scenario scenario = new Scenario()
                .NonRandom()
                .Random(amount: 10);

            return new CasesGenerator<string, double, double, DateTime>(scenario)
                .Select(c => new TestCaseData(c));
        }
    }
```
## Fuzz providers
  - List of all currently available values used for fuzzing can be found in [Scenario.cs](./Fuzzer/Scenario.cs)
  - You can write Your own provider:
    - by implementing `Fuzzer.Fuzzers.IFuzzer<>` like in [CustomFuzzerFixture.cs](./FuzzerTests/CustomFuzzerFixture.cs)
    - by making incubator `Func<>` like in [IncubatorFuzzerFixture.cs](./FuzzerTests/IncubatorFuzzerFixture.cs)
    - by providing literal like:
      ```cs
      scenario.Add(ConstantFuzzer.Create( /* literal in here */ ));
      ```
    - types that don't have added provider will be tested as `default()`

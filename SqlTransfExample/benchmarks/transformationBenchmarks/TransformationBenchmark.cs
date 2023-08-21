using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using SqlTransfLib.core.transformation.delegates;

namespace SqlTransfExample.benchmarks
{
    [MemoryDiagnoser]
    public class Benchmark
    {


        [Benchmark]
        public void RunWithDelegates()
        {
            int SIZE = 1000;
            Transform[] delegates = new Transform[SIZE];

            for (int i = 0; i < SIZE; ++i)
            {
                delegates[i] = (string input) => { return input.ToLower() + i; };
            }

            for (int i = 0; i < SIZE; ++i)
            {
                delegates[i]("BENCHMARK" + i);
            }

        }


        [Benchmark]
        public void RunWithClasses()
        {
            int SIZE = 1000;
            ImplementationsDeprecated[] implementations = new ImplementationsDeprecated[SIZE];


            for (int i = 0; i < SIZE; ++i)
            {
                implementations[i] = new((string input) => { return input.ToLower() + i; });
            }

            for (int i = 0; i < SIZE; ++i)
            {
                implementations[i].Transform("BENCHAMRK" + i);
            }
        }


    }


    public static class TransformationBenchmark
    {

        /**
            <summary>
                Testing performnace of transformation core implementation
            </summary>

            <remarks>
                Testing if it is better to just use delegates and then chain them manually using array,
                or is it better to have classes that wraps delegates and have refrences to next transformation.
            </remarks>

        */
        public static void RunImplementationBenchmark()
        {
            var results = BenchmarkRunner.Run<Benchmark>();
        }
    }
}
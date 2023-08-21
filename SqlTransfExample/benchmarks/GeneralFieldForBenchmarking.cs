using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace SqlTransfExample.benchmarks
{
    [MemoryDiagnoser]
    public class GeneralFieldForBenchmarking
    {


        [Benchmark]
        public void twoPointerLoop_prmitive()
        {
            int[] array = { 23, 32, 123, 1, 33, 43, 1, 0, 23, 45, 8 };


            for (int i = 0; i < array.Length; ++i)
            {
                if (array[i] == 33) return;
            }
        }

        [Benchmark]
        public void twoPointerLoop_sophistcated()
        {
            int[] array = { 23, 32, 123, 1, 33, 43, 1, 0, 23, 45, 8 };

            int i = 0;
            int j = array.Length - 1;

            while (i < j)
            {
                if (array[i] == 33) return;
                if (array[j] == 33) return;
                ++i;
                --j;
            }
        }
    }



    public static class BenchmarkField
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
            var results = BenchmarkRunner.Run<GeneralFieldForBenchmarking>();
        }
    }
}
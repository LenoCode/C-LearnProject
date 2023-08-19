using SqlTransfLib.core.transformation.delegates;
using BenchmarkDotNet.Running;

namespace SqlTransfTests.transformationTests.basicTests
{

    [MemoryDiagnoser]
    public class BasicTransformationTests : TestTools
    {

        public BasicTransformationTests(ITestOutputHelper output) : base(output)
        {

        }


       

        [Theory]
        [ClassData(typeof(BasicSelectQueriesGenerator))]
        public void TestBasicTransformation(string query)
        {
            _output.WriteLine(query);
        }

    }
}
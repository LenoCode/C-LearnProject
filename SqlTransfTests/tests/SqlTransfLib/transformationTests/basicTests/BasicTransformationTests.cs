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
        [ClassData(typeof(SQLInnerQueriesDataGenerator))]
        public void Test_if_appropriate_transformation_returns(string query, QUERY_TYPES expected)
        {
            QUERY_TYPES result;
            Transformations.InitQueryFormating(query, out result);
            Assert.Equal(expected, result);
        }



        [Theory]
        [ClassData(typeof(SQLInnerQueriesDataGenerator))]
        public void Test_SQL_Select_formating_function(string query, QUERY_TYPES expected)
        {
            QUERY_TYPES result;
            Transform formatFunction = Transformations.InitQueryFormating(query, out result);
            formatFunction(query);
        }

    }
}
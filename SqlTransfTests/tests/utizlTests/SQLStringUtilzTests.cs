using SqlTransfLib.utilz;

namespace SqlTransfTests.tests.utizlTests
{
    public class SQLStringUtilzTests : TestTools
    {
        public SQLStringUtilzTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {

        }

        [Theory]
        [ClassData(typeof(SQLInnerQueriesDataGenerator))]
        public void Check_If_Parsing_SQLQuery_Returns_Proper_List_Of_Inner_Queries(string query){
            
            string[] splitQueries;
            string queryTemplate;

            SQLStringUtilz.DivideIntoSeperateQueries(query,out splitQueries,out queryTemplate);

            //string finalQuery = SQLStringUtilz.CombineInOnQuery(splitQueries,queryTemplate);

           // Assert.Equal(query,queryTemplate);

        }
        
    }
}
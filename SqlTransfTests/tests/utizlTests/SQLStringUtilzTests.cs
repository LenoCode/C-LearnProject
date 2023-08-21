using SqlTransfLib.utilz;

namespace SqlTransfTests.tests.utizlTests
{
    public class SQLStringUtilzTests : TestTools
    {
        public SQLStringUtilzTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {

        }

        [Theory(DisplayName = "Find all tables or queries from SELECT query")]
        [MemberData(nameof(ExtractTableFromSelectData))]
        public void Test_Function_ExtractTablesFromSelectQuery(string query, string[] expected)
        {

            string[] results = SQLStringUtilz.ExtractTablesFromSelectQuery(query);

            Assert.Equal(expected, results);
        }

        /******************************************************************************

            DATA SAMPLE
        */
        public static IEnumerable<object[]> ExtractTableFromSelectData()
        {
            yield return new object[] { "SELECT * FROM table1,table2", new object[] { "table1", "table2" } };
            yield return new object[] { "SELECT * FROM (SELECT * FROM inside)", new object[] { "SELECT * FROM inside" } };
        }



        [Theory(DisplayName = "Find all tables that from SELECT query")]
        [MemberData(nameof(ExtractTableFromPartOfSql))]
        public void Test_Function_FindTablesAndExtractThem(string partOfQuery, string[] expected)
        {

            string[] results = SQLStringUtilz.FindTablesAndExtractThem(partOfQuery);

            Assert.Equal(expected, results);
        }
        /******************************************************************************

            DATA SAMPLE
        */
        public static IEnumerable<object[]> ExtractTableFromPartOfSql()
        {
            yield return new object[] { "from table1,table2", new object[] { "table1", "table2" } };
        }





        [Theory(DisplayName = "Extract inner query from select")]
        [MemberData(nameof(ExtractInnerQueryFromSelect))]
        public void Test_Function_ExtractInnerQueryFromSelect(string partOfQuery, string expected)
        {
            string results = SQLStringUtilz.ExtractInnerQuery(partOfQuery);

            Assert.Equal(expected, results);
        }

        /******************************************************************************

            DATA SAMPLE
        */
        public static IEnumerable<object[]> ExtractInnerQueryFromSelect()
        {
            yield return new object[] { "(SELECT * FROM inside)", "SELECT * FROM inside" };
            yield return new object[] { "(SELECT * FROM (SELECT * FROM inside2) )", "SELECT * FROM (SELECT * FROM inside2) " };
        }














    }
}
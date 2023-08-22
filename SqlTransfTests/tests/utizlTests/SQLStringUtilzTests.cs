using SqlTransfLib.utilz;
using Xunit.Sdk;

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



        [Fact(DisplayName = "Test extraction of columns from sql query")]
        public void Test_Function_For_Extraction_Of_Columns()
        {
            string query = "SELECT column1,column2 FROM table";
            string query1 = "SELECT (column1,column2) FROM table";
            try
            {
                string[] results = SQLStringUtilz.FindColumnsFromSELECTQuery(query);
                string[] results1 = SQLStringUtilz.FindColumnsFromSELECTQuery(query1);
                
                Assert.Equal(new string[]{"column1","column2"},results);
                Assert.Equal(new string[]{"(column1","column2)"},results1);
            }
            catch (ArgumentException e)
            {
                Assert.Fail("Exception was thrown when it should not");
            }
        }


        [Fact(DisplayName = "Test extraction of columns from wrong query, checking if exception Missing FROM  is thrown")]
        public void Test_Exception_FROM_MISSING_IsThrown_For_Extraction_Of_Columns()
        {
            string query = "SELECT column1,column2 table";
            try
            {
                string[] results = SQLStringUtilz.FindColumnsFromSELECTQuery(query);
                Assert.Fail("Exception was not thrown");
            }
            catch (ArgumentException e)
            {

                Assert.Equal("FROM is missing from query", e.Message);
            }
        }


        [Fact(DisplayName = "Test extraction of columns from wrong query, checking if exception Missing SELECT is thrown")]
        public void Test_Exception_SELECT_MISSING_IsThrown_For_Extraction_Of_Columns()
        {
            string query = "column1,column2 FROM table";
            try
            {
                string[] results = SQLStringUtilz.FindColumnsFromSELECTQuery(query);
                Assert.Fail("Exception was not thrown");
            }
            catch (ArgumentException e)
            {
                Assert.Equal("column1,column2 FROM table -> query is in wrong format", e.Message);
            }
        }













    }
}
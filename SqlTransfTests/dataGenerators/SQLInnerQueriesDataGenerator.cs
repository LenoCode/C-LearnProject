using System.Collections;
using System.Runtime.CompilerServices;
using SqlTransfLib.core.transformation.delegates;

namespace SqlTransfTests.dataGenerators
{
    public class SQLInnerQueriesDataGenerator : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "SELECT * FROM (SELECT * FROM inside)",QUERY_TYPES.SELECT};

            yield return new object[] { "SELECT * FROM (SELECT * FROM (SELECT * FROM double_inside))", QUERY_TYPES.SELECT  };
        }


        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<object>)this).GetEnumerator();
    }
}
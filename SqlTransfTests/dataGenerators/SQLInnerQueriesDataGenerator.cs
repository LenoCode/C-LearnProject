using System.Collections;
using System.Runtime.CompilerServices;

namespace SqlTransfTests.dataGenerators
{
    public class SQLInnerQueriesDataGenerator : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "SELECT * FROM (SELECT * FROM inside)"};
            yield return new object[] { "SELECT * FROM (SELECT * FROM (SELECT * FROM double_inside))"};
        }


        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<object>)this).GetEnumerator();
    }
}
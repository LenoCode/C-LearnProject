using System.Collections;

namespace SqlTransfTests.dataGenerators
{
    public class BasicSelectQueriesGenerator : IEnumerable<object[]>
    {

        private readonly IEnumerable<string> _BASIC_SELECT_SQL_QUERIES;

        public BasicSelectQueriesGenerator()
        {
            string rootDir = TestTools.GetRootDir();

            _BASIC_SELECT_SQL_QUERIES = File.ReadAllText($"{rootDir}{Path.DirectorySeparatorChar}sqlFiles{Path.DirectorySeparatorChar}basicSelectQueries.sql")
                                             .Split(";")
                                             .Where(x => x.Length>1)
                                             .Select(q => q.Replace("\n",string.Empty) + ';');
        }


        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<object>)this).GetEnumerator();

        IEnumerator<object[]> IEnumerable<object[]>.GetEnumerator()
        {
            foreach (var query in _BASIC_SELECT_SQL_QUERIES)
            {
                yield return new object[] { query };
            }
        }



    }
}
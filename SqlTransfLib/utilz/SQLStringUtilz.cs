namespace SqlTransfLib.utilz
{
    public static class SQLStringUtilz
    {
        const short FROM_CHAR_LENGTH = 4;

        const short SELECT_CHAR_LENGTH = 6;


        /**

            <summary>
                This function will extract all tables SELECT query wants to get data from or if select gets data from inner queries
            </summary>

            <returns>
                string[]
            </returns>
        */
        public static string[] ExtractTablesFromSelectQuery(string queryOrg)
        {
            string query = queryOrg.ToLower();
            if (query.IndexOf("from") is var index && (index != -1))
            {
                index += FROM_CHAR_LENGTH;
                for (int i = index; i < query.Length; ++i)
                {
                    if (query[i] == ' ') continue;

                    if (query[i] == '(')
                    {
                        return new string[] { ExtractInnerQuery(queryOrg.Substring(i)) };
                    }
                    else
                    {
                        return FindTablesAndExtractThem(queryOrg.Substring(i));
                    }
                }
            }
            return new string[0];
        }


        /**
            <remarks>
            
                Basic point is to find a last closing bracket that matches the first inner query we want to find.

                example SELECT * FROM ( SELECT * FROM (SELECT * FROM dobuleInside) )
                    -> if we search for first level then we have (SELECT * FROM (SELECT * FROM dobuleInside )  )<- this is the last bracket we are searching for 
            </remarks>


            <param name="partOfSelectQuery">
                we will get query like this (SELECT * FROM (SELECT * FROM dobuleInside) ) for example
            </param>

             <returns>
                string[] -> {'table1','table2'}
            </returns>

        */
        public static string ExtractInnerQuery(string subquery)
        {
            int openBracketCount = 1;

            int i = 1;
            int lastIndex = -1;
            while (openBracketCount != 0)
            {
                if (subquery[i] == ')')
                {
                    openBracketCount--;

                    if (openBracketCount == 0) lastIndex = i;

                }
                else if (subquery[i] == '(')
                {
                    openBracketCount++;
                }
                ++i;
            }
            return subquery.Substring(1, lastIndex - 1);
        }

        /**
            <summary>
                This function extract tables name from query.
            </summary>

            <param name="partOfSelectQuery">
                we will get query like this 'from table1,table2'
            </param>

             <returns>
                string[] -> {'table1','table2'}
            </returns>

        */
        public static string[] FindTablesAndExtractThem(string partOfSelectQuery)
        {
            partOfSelectQuery = partOfSelectQuery.Replace("from", "");
            partOfSelectQuery = new string(partOfSelectQuery.ToCharArray().Where(x => !Char.IsWhiteSpace(x)).ToArray());

            return partOfSelectQuery.Split(",");
        }



        /**
           <summary>
               This function extract columns name from query.
           </summary>

           <param name="query">
               ordinary SQL SELECT query. 
               RULE -> it must not contain inner queries (SELECT * FROM (SELECT * FROM inside ))    X
           </param>

            <returns>
               string[] -> {'column1','column2'}
           </returns>

       */
        public static string[] FindColumnsFromSELECTQuery(string query)
        {
            var lowerCaseQuery = query.ToLower();
            if (!lowerCaseQuery.StartsWith("select"))
            {
                throw new ArgumentException($"{query} -> query is in wrong format");
            }
            int indexOfColumnsBegin = lowerCaseQuery.IndexOf("select") + SELECT_CHAR_LENGTH;


            if (lowerCaseQuery.IndexOf("from") is var fromIndex && fromIndex != -1)
            {
                string columns = lowerCaseQuery.Substring(indexOfColumnsBegin, fromIndex - indexOfColumnsBegin);

                columns = new string(columns
                                    .Where(c => !Char.IsWhiteSpace(c))
                                    .ToArray());

                return columns.Split(",");
            }
            else
            {
                throw new ArgumentException($"FROM is missing from query");
            }
        }
    }
}
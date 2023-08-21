namespace SqlTransfLib.utilz
{
    public static class SQLStringUtilz
    {
        const short FROM_CHAR_LENGTH = 4;


        /**

            <summary>
                This function will extract all tables SELECT query wants to get data from or if select gets data from inner queries
            </summary>

            <returns>
                string[]
            </returns>
        */
        public static string[] ExtractTablesFromSelectQuery(string query){
            query = query.ToLower();

            if( query.IndexOf("from") is var index   && (index != -1) ){
                index += FROM_CHAR_LENGTH;

                for(int i = index; i < query.Length; ++i){
                    if(query[i] == ' ')continue;

                    if(query[i] == '('){

                        
                    }else{
                        return FindTablesAndExtractThem(query.Substring(i));
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
        public static string ExtractInnerQuery(string subquery){
            int openBracketCount = 1;

            int i = 1;
            int lastIndex = -1;
            while(openBracketCount != 0){
                if(subquery[i] == ')'){
                    openBracketCount--;

                    if(openBracketCount == 0)lastIndex = i;
                    
                }else if(subquery[i] == '('){
                    openBracketCount++;
                }
                ++i;
            }
            return subquery.Substring(1,lastIndex-1);
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
        public static string[] FindTablesAndExtractThem(string partOfSelectQuery){
            partOfSelectQuery = partOfSelectQuery.Replace("from","");
            partOfSelectQuery =  new string( partOfSelectQuery.ToCharArray().Where(x=>!Char.IsWhiteSpace(x)).ToArray() );

            return partOfSelectQuery.Split(",");
        }

        /**
            <summary>
                It takes query like this(SELECT * FROM (SELECT * FROM inside) as b  ) and seperate into SELECT * FROM as b and SELECT * FROM inside 
            </summary>
        */
        public static void DivideIntoSeperateQueries(string input, out string[] splitQueries, out string queryTemplate)
        {
            List<string> queries = new();

            queryTemplate = "";

            while (input.IndexOf('(') is var index && (index != -1))
            {
           

                Stack<int> openBracketIndexes = new();
                openBracketIndexes.Push(index);
                int i = 0;

                while(openBracketIndexes.Count != 0){
                    
                    if(input[i] == ')'){
                        int startIndex = openBracketIndexes.Pop();
                        string subquery = input.Substring(startIndex,(i - startIndex)+1); 
                        input = input.Replace(subquery,$"<b>{{{queries.Count}}}</b>");

                    }
                    else if(input[i] == '('){
                        openBracketIndexes.Push(i);
                    }
                    ++i;

                }
            }
            splitQueries = queries.ToArray();
        }
    }
}
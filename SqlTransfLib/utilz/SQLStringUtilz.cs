namespace SqlTransfLib.utilz
{
    public static class SQLStringUtilz
    {


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
               
                int countOfOpenedBracket = 1;
                int lastIndex = -1;

                for(int i = index+1; countOfOpenedBracket != 0; ++i){

                    if(input[i] == ')'){
                        lastIndex = i;
                        --countOfOpenedBracket;
                    }
                    else if(input[i] == '(') ++countOfOpenedBracket;  
               }
            

                string sub = input.Substring(index+1,lastIndex-index-1);
                queries.Add(sub);

                input = input.Replace($"({sub})","{0}");
            }

            splitQueries = queries.ToArray();
        }
    }
}
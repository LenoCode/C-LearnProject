using System.Runtime.CompilerServices;

namespace SqlTransfTests
{


    /**
        <remarks>


            command to run test and print all test runned -> dotnet test -l "console;verbosity=normal"
        
        </remarks>
    */

    public class TestTools
    {
        protected readonly ITestOutputHelper _output;


        protected readonly string ROOT_DIR;



        protected TestTools(ITestOutputHelper testOutputHelper)
        {
            this._output = testOutputHelper;

            this.ROOT_DIR = GetRootDir();

        }



        public static string GetRootDir([CallerFilePath] string filePath = null)
        {
            return filePath.Substring(0, filePath.LastIndexOf("/"));
        }
    }
}
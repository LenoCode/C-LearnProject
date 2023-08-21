using System.Diagnostics;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace SqlTransfLib.core.transformation.delegates
{
    public delegate string Transform(string input);


    public enum QUERY_TYPES{
      SELECT,
      INSERT,
      DELETE,
      UPDATE
    }

    /**

      <summary>
        Currently deprecated
      </summary>
    */
    [MemoryDiagnoser]
    public class ImplementationsDeprecated
    {
          private readonly Transform _transformFunc;


          public ImplementationsDeprecated(Transform transform){
            this._transformFunc = transform;
          }


          public string Transform(string input) => this._transformFunc(input);      
    }



    public static class Transformations{




      public static string StartSelectQueryFormating(string input){
          return input;
      }


      /**
        <summary>
          Entry point for formatting query
        </summary>
        <remarks>
          Functions inspects the beggining of query to deterimne what kind of query is it about.
          Is it about SELECT or INSERT for example.

          Then functin returns appropriate Transform function.
        </remarks>


        <returns>
          <see cref="Transform"/>?
        </returns>

      */
      public static Transform InitQueryFormating(string query,out QUERY_TYPES queryType){
      
        if(query.StartsWith("SELECT") || query.StartsWith("select")){
          queryType = QUERY_TYPES.SELECT;
          return  StartSelectQueryFormating;
        }
        else throw new Exception("Query is not formatted properly");
    }

    }


}
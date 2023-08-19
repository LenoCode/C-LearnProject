using System.Diagnostics;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace SqlTransfLib.core.transformation.delegates
{
    public delegate string Transform(string input);


    [MemoryDiagnoser]
    public class Implementations
    {
          private readonly Transform _transformFunc;


          public Implementations(Transform transform){
            this._transformFunc = transform;
          }


          public string Transform(string input) => this._transformFunc(input);      
    }
}
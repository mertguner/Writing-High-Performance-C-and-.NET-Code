using BenchmarkDotNet.Running;

namespace Benchmark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Case8_CPlusPlusLib>();
            //var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
        }       
    }
}

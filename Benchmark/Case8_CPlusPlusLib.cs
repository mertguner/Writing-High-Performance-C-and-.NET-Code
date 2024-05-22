using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark
{
    [ShortRunJob, MarkdownExporterAttribute.GitHub, RPlotExporter, MemoryDiagnoser]
    public class Case8_CPlusPlusLib
    {
        [Params(1000000)]
        public int N;
        static List<int> SieveOfEratosthenes(int n)
        {
            bool[] isPrime = new bool[n + 1];
            for (int i = 2; i <= n; i++)
            {
                isPrime[i] = true;
            }

            for (int p = 2; p * p <= n; p++)
            {
                if (isPrime[p])
                {
                    for (int i = p * p; i <= n; i += p)
                    {
                        isPrime[i] = false;
                    }
                }
            }

            List<int> primes = new List<int>();
            for (int i = 2; i <= n; i++)
            {
                if (isPrime[i])
                {
                    primes.Add(i);
                }
            }

            return primes;
        }

        [Benchmark]
        public void CaseCSharp()
        {
            SieveOfEratosthenes(N);
        }

        [DllImport("D:\\GitHub\\Writing-High-Performance-C-and-.NET-Code\\Benchmark\\bin\\Release\\net8.0-windows\\CPlusPlusDll.dll")]
        public static extern int sieveOfEratosthenesTest(int N);

        [DllImport("D:\\GitHub\\Writing-High-Performance-C-and-.NET-Code\\Benchmark\\bin\\Release\\net8.0-windows\\CPlusPlusDll.dll")]
        public static extern int sieveOfEratosthenesFalseTest(int N);

        [Benchmark]
        public void CaseCPlusPlusTrue()
        {
            sieveOfEratosthenesTest(N);
        }
        [Benchmark]
        public void CaseCPlusPlusFalse()
        {
            sieveOfEratosthenesFalseTest(N);
        }
    }
}

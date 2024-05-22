using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark
{
    [MarkdownExporterAttribute.GitHub, RPlotExporter, MemoryDiagnoser]
    public class Case9_Parallelization
    {
        private int[] data = { 0, 1, 2, 3, 4, 0, 1, 2, 3, 4, 0, 1, 2, 3, 4, 0, 1, 2, 3, 4 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Process(int value, int value2)
        {
            return value + value2;
        }

        [Benchmark]
        public void CaseTrue()
        {
            Parallel.For(0, 10000, i =>
            {
                Process(data[i % (data.Length - 1)], i);
            });
        }

        [Benchmark]
        public void CaseFalse()
        {
            for (int i = 0; i < 10000; i += 1)
            {
                Process(data[i % (data.Length - 1)], i);
            }
        }
    }
}

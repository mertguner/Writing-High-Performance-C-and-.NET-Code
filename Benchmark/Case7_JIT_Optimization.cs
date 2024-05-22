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
    public class Case7_JIT_Optimization
    {
        public int[] data = { 0, 1, 2, 3, 4, 0, 1, 2, 3, 4, 0, 1, 2, 3, 4, 0, 1, 2, 3, 4 };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Process(int value, int value2)
        {
            return value + value2;
        }

        public int Process2(int value, int value2)
        {
            return value + value2;
        }

        [Benchmark]
        public int CaseTrue()
        {
            int total = 0;
            for (int i = 0; i < data.Length; i += 1)
            {
                total += Process2(data[i], i);
            }
            return total;
        }

        [Benchmark]
        public int CaseFalse()
        {
            int total = 0;
            for (int i = 0; i < data.Length; i += 1)
            {
                total += Process(data[i], i);
            }
            return total;
        }
    }
}

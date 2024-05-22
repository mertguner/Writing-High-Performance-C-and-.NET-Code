using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark
{
    [MarkdownExporterAttribute.GitHub, RPlotExporter, MemoryDiagnoser]
    public class Case3_Loop_Element
    {
        public int[] array = { 0, 1, 2, 3, 4, 5 };

        [Benchmark]
        public void CaseTrue()
        {
            int limit = ((int)Math.Pow(array.Length, 2));
            for (int i = 0; i < limit; i++) { }
        }

        [Benchmark]
        public void CaseFalse()
        {
            for (int i = 0; i < Math.Pow(array.Length, 2); i++) { }
        }
    }
}

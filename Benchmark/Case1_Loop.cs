using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark
{
    [MarkdownExporterAttribute.GitHub, RPlotExporter, MemoryDiagnoser]
    public class Case1_Loop
    {
        [Benchmark]
        public void CaseTrue()
        {
            for (int i = 0; i < 1000; i++) { }
        }

        [Benchmark]
        public void CaseFalse()
        {
            for (double i = 0.0; i < 1000.0; i++) { }
        }
    }
}

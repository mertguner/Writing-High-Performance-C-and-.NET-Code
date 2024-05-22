using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark
{
    [MarkdownExporterAttribute.GitHub, RPlotExporter, MemoryDiagnoser]
    public class Case2_Condition_Grouping
    {
        public int x = 5;
        public int y = 6;

        [Benchmark]
        public void CaseTrue()
        {
            if ((x > 0 && x < 10) && (y > 0 && y < 10)) { }
        }

        [Benchmark]
        public void CaseFalse()
        {
            if (x > 0 && x < 10 && y > 0 && y < 10) { }
        }
    }
}

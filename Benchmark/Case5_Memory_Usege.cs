using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark
{
    [MarkdownExporterAttribute.GitHub, RPlotExporter, MemoryDiagnoser]
    public class Case5_Memory_Usege
    {
        [Benchmark]
        public void CaseTrue()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < 100; i++)
            {
                builder.Append(i);
            }
            string result = builder.ToString();
        }

        [Benchmark]
        public void CaseFalse()
        {
            string result = "";
            for (int i = 0; i < 100; i++)
            {
                result += i;
            }

        }
    }
}

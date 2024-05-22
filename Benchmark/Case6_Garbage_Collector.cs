using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark
{
    [MarkdownExporterAttribute.GitHub, RPlotExporter, MemoryDiagnoser]
    public class Case6_Garbage_Collector
    {
        [Benchmark]
        public void CaseTrue()
        {
            Point p = new Point();
            for (int i = 0; i < 1000000; i++)
            {
                p.X = i;
                p.Y = i + 1;
            }
        }

        [Benchmark]
        public void CaseFalse()
        {
            for (int i = 0; i < 1000000; i++)
            {
                Point p = new Point(i, i + 1);
            }
        }
    }
}

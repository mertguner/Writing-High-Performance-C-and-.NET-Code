using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark
{
    [MarkdownExporterAttribute.GitHub, RPlotExporter, MemoryDiagnoser]
    public class Case4_Condition
    {
        [Benchmark]
        public void CaseTrue()
        {
            HashSet<int> numbersSet = new HashSet<int> { 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5 };
            int sum = 0;

            for (int i = 0; i < numbersSet.Count; i++) 
            {
                if (numbersSet.Contains(i % 6))
                {
                    sum += i;
                }
            }
        }

        [Benchmark]
        public void CaseFalse()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5 };
            int sum = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers.Contains(i % 6))
                {
                    sum += i;
                }
            }
        }
    }
}

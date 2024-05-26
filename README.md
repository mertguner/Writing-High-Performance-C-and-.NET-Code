# Writing-High-Performance-C-and-.NET-Code
Devnote conference. Subject: "Writing High-Performance C# and .NET Code"


```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.4412/22H2/2022Update)
Intel Core i7-9750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.205
  [Host]     : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2
  ShortRun   : .NET 8.0.5 (8.0.524.21615), X64 RyuJIT AVX2

```

# Case1_Loop
| Method    | Mean     | Error    | StdDev   | Allocated |
|---------- |---------:|---------:|---------:|----------:|
| CaseTrue  | 252.9 ns |  4.66 ns |  4.13 ns |         - |
| CaseFalse | 937.1 ns | 18.42 ns | 19.71 ns |         - |

# Case2_Condition_Grouping
| Method    | Mean      | Error     | StdDev    | Allocated |
|---------- |----------:|----------:|----------:|----------:|
| CaseTrue  | 0.0000 ns | 0.0025 ns | 0.0019 ns |         - |
| CaseFalse | 0.0008 ns | 0.0017 ns | 0.0015 ns |         - |

# Case3_Loop_Element
| Method    | Mean      | Error    | StdDev   | Allocated |
|---------- |----------:|---------:|---------:|----------:|
| CaseTrue  |  42.28 ns | 0.250 ns | 0.234 ns |         - |
| CaseFalse | 994.54 ns | 3.261 ns | 2.890 ns |         - |

# Case4_Condition
| Method    | Mean      | Error     | StdDev    | Median    | Allocated |
|---------- |----------:|----------:|----------:|----------:|----------:|
| CaseTrue  | 251.2 ns | 0.0021 ns | 0.0017 ns | 0.0010 ns |         - |
| CaseFalse | 313.6 ns | 0.0019 ns | 0.0017 ns | 0.0000 ns |         - |

# Case5_Memory_Usege
| Method    | Mean       | Error    | StdDev    | Median     | Gen0   | Allocated |
|---------- |-----------:|---------:|----------:|-----------:|-------:|----------:|
| CaseTrue  |   602.8 ns |  7.22 ns |   6.76 ns |   600.3 ns | 0.2031 |   1.25 KB |
| CaseFalse | 1,930.6 ns | 66.37 ns | 192.55 ns | 1,832.6 ns | 3.3226 |  20.37 KB |

# Case6_Garbage_Collector
| Method    | Mean     | Error   | StdDev  | Allocated |
|---------- |---------:|--------:|--------:|----------:|
| CaseTrue  | 227.8 μs | 1.23 μs | 1.09 μs |         - |
| CaseFalse | 229.4 μs | 2.55 μs | 2.38 μs |         - |

# Case7_JIT_Optimization
| Method    | Mean     | Error     | StdDev    | Allocated |
|---------- |---------:|----------:|----------:|----------:|
| CaseTrue  | 9.370 ns | 0.1082 ns | 0.0959 ns |         - |
| CaseFalse | 9.208 ns | 0.0181 ns | 0.0169 ns |         - |

# Case8_CPlusPlusLib
| Method             | N       | Mean     | Error     | StdDev    | Gen0     | Gen1     | Gen2     | Allocated |
|------------------- |-------- |---------:|----------:|----------:|---------:|---------:|---------:|----------:|
| CaseCSharp         | 1000000 | 3.829 ms | 0.2206 ms | 0.0121 ms | 519.5313 | 500.0000 | 500.0000 | 2049212 B |
| CaseCPlusPlusTrue  | 1000000 | 2.771 ms | 0.5431 ms | 0.0298 ms |        - |        - |        - |       2 B |
| CaseCPlusPlusFalse | 1000000 | 3.808 ms | 0.6354 ms | 0.0348 ms |        - |        - |        - |       3 B |

# Case9_Parallelization (The result is not successful with BenchmarkDotNet)
| Method    | Mean     | Error    | StdDev   | Gen0   | Allocated |
|---------- |---------:|---------:|---------:|-------:|----------:|
| CaseTrue  | 27.94 μs | 0.197 μs | 0.184 μs | 0.6409 |    4042 B |
| CaseFalse | 18.69 μs | 0.049 μs | 0.041 μs |      - |         - |
```

BenchmarkDotNet v0.13.7, Ubuntu 22.04.3 LTS (Jammy Jellyfish)
AMD Ryzen 7 5800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK 7.0.400
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2


```
|              Method |       Mean |     Error |    StdDev |   Gen0 | Allocated |
|-------------------- |-----------:|----------:|----------:|-------:|----------:|
|              Tester | 4,409.9 ns | 101.99 ns | 300.71 ns | 0.2823 |  23.18 KB |
| TesterAnotherMethod |   752.2 ns |  12.82 ns |  13.72 ns | 0.0162 |   1.38 KB |

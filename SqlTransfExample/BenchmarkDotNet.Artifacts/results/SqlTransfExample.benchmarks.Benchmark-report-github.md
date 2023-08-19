```

BenchmarkDotNet v0.13.7, Ubuntu 22.04.3 LTS (Jammy Jellyfish)
AMD Ryzen 7 5800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK 7.0.400
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2


```
|           Method |     Mean |    Error |   StdDev |   Gen0 |   Gen1 | Allocated |
|----------------- |---------:|---------:|---------:|-------:|-------:|----------:|
| RunWithDelegates | 83.53 μs | 0.263 μs | 0.219 μs | 3.4180 | 0.7324 | 280.98 KB |
|   RunWithClasses | 90.43 μs | 0.210 μs | 0.186 μs | 3.6621 | 1.0986 | 304.42 KB |

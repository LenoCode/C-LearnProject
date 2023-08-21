```

BenchmarkDotNet v0.13.7, Ubuntu 22.04.3 LTS (Jammy Jellyfish)
AMD Ryzen 7 5800H with Radeon Graphics, 1 CPU, 16 logical and 8 physical cores
.NET SDK 7.0.400
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2


```
|                      Method |     Mean |    Error |   StdDev |   Gen0 | Allocated |
|---------------------------- |---------:|---------:|---------:|-------:|----------:|
|     twoPointerLoop_prmitive | 11.28 ns | 0.064 ns | 0.060 ns | 0.0008 |      72 B |
| twoPointerLoop_sophistcated | 12.35 ns | 0.024 ns | 0.020 ns | 0.0008 |      72 B |

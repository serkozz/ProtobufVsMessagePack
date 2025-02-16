```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22621.675/22H2/2022Update/SunValley2)
Unknown processor
.NET SDK 9.0.102
  [Host]     : .NET 9.0.1 (9.0.124.61010), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.1 (9.0.124.61010), X64 RyuJIT AVX2


```
| Method                                  | Mean                | Error            | StdDev           | Gen0         | Gen1        | Gen2       | Allocated     |
|---------------------------------------- |--------------------:|-----------------:|-----------------:|-------------:|------------:|-----------:|--------------:|
| SerializeUsingMessagePack               |            694.4 ns |          2.10 ns |          1.96 ns |       0.2594 |           - |          - |         544 B |
| DeserializeUsingMessagePack             |          1,727.8 ns |          2.84 ns |          2.52 ns |       0.7572 |           - |          - |        1584 B |
| SerializeMillionArrayUsingMessagePack   | 25,944,435,983.3 ns | 50,395,506.13 ns | 39,345,496.32 ns | 3298000.0000 | 762000.0000 | 10000.0000 | 18976329896 B |
| DeserializeMillionArrayUsingMessagePack | 27,998,072,000.0 ns | 76,356,273.75 ns | 63,760,946.79 ns | 4059000.0000 | 803000.0000 | 10000.0000 | 20900244600 B |

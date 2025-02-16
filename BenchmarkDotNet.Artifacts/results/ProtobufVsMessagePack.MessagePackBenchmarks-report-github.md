```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22621.675/22H2/2022Update/SunValley2)
Unknown processor
.NET SDK 9.0.102
  [Host]     : .NET 9.0.1 (9.0.124.61010), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.1 (9.0.124.61010), X64 RyuJIT AVX2


```
| Method                      | Mean       | Error   | StdDev  | Gen0   | Allocated |
|---------------------------- |-----------:|--------:|--------:|-------:|----------:|
| SerializeUsingMessagePack   |   717.3 ns | 1.07 ns | 0.95 ns | 0.2594 |     544 B |
| DeserializeUsingMessagePack | 1,783.1 ns | 3.15 ns | 2.79 ns | 0.7572 |    1584 B |

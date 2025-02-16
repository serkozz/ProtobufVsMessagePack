```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.22621.675/22H2/2022Update/SunValley2)
Unknown processor
.NET SDK 9.0.102
  [Host]     : .NET 9.0.1 (9.0.124.61010), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.1 (9.0.124.61010), X64 RyuJIT AVX2


```
| Method                       | Mean       | Error   | StdDev  | Gen0   | Allocated |
|----------------------------- |-----------:|--------:|--------:|-------:|----------:|
| SerializeUsingProtobuffers   |   750.8 ns | 4.47 ns | 3.97 ns | 0.3786 |     792 B |
| DeserializeUsingProtobuffers | 1,518.8 ns | 2.53 ns | 2.12 ns | 0.9899 |    2072 B |

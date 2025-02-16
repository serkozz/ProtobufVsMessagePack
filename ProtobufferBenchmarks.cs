using ProtobufVsMessagePack.ProtobufModel;
using BenchmarkDotNet.Attributes;
using Google.Protobuf;

namespace ProtobufVsMessagePack;

[MemoryDiagnoser]
public class ProtobufferBenchmarks
{
    public static Employee Employee => GenerateEmployee();
    public static byte[] EmployeePacked => PackEmployee();

    private static Employee GenerateEmployee()
    {
        City moscow = new()
        {
            Country = "Russia",
            Name = "Moscow",
            Population = 12_000_000,
            State = "Moscow"
        };
        Employee employee = new()
        {
            City = moscow,
            Contact = new() { Email = "serezha-kozlov.2002@mail.ru", PhoneNumber = "12345678910" },
            HomeAddress = new()
            {
                City = moscow,
                Street = "Pushkina",
                PostalCode = "001"
            },
            Age = 23,
            EmploymentStatus = Status.Pending,
            Name = "serkozz",
        };
        employee.Skills.Add([
            new() { Name = "C#", Description = "Seems good", ProficiencyLevel = 7},
            new() { Name = "CSS", Description = ":(", ProficiencyLevel = 3}
        ]);
        return employee;
    }

    private static byte[] PackEmployee() => Employee.ToByteArray();

    [Benchmark]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>")]
    public void SerializeUsingProtobuffers() => _ = Employee.ToByteArray();

    [Benchmark]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>")]
    public void DeserializeUsingProtobuffers() => _ = Employee.Parser.ParseFrom(EmployeePacked);
}
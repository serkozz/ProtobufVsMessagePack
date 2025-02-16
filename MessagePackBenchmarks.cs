using ProtobufVsMessagePack.MessagePackModel;
using BenchmarkDotNet.Attributes;
using MessagePack;

namespace ProtobufVsMessagePack;

[MemoryDiagnoser]
public class MessagePackBenchmarks
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
        return new Employee()
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
            Skills = [
                new() { Name = "C#", Description = "Seems good", ProficiencyLevel = 7},
                new() { Name = "CSS", Description = ":(", ProficiencyLevel = 3}
            ]
        };
    }

    private static byte[] PackEmployee() => MessagePackSerializer.Serialize(Employee);

    [Benchmark]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>")]
    public void SerializeUsingMessagePack() => _ = MessagePackSerializer.Serialize(Employee);

    [Benchmark]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>")]
    public void DeserializeUsingMessagePack() => _ = MessagePackSerializer.Deserialize<Employee>(EmployeePacked);
}
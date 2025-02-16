using ProtobufVsMessagePack.MessagePackModel;
using BenchmarkDotNet.Attributes;
using MessagePack;
using Bogus;

namespace ProtobufVsMessagePack;

[MemoryDiagnoser]
public class MessagePackBenchmarks
{
    public static Employee Employee => GenerateEmployee();
    public static List<Employee> Employees => GenerateRandomArray();
    public static byte[] EmployeePacked => PackEmployee();
    public static List<byte[]> EmployeesPacked => PackEmployees();

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

    private static List<Employee> GenerateRandomArray()
    {
        var cityFaker = new Faker<City>()
            .RuleFor(c => c.Name, f => f.Address.City())
            .RuleFor(c => c.State, f => f.Address.State())
            .RuleFor(c => c.Country, f => f.Address.Country())
            .RuleFor(c => c.Population, f => f.Random.Int(100000, 5000000));

        var skillFaker = new Faker<Skill>()
            .RuleFor(s => s.Name, f => f.Random.Word())
            .RuleFor(s => s.ProficiencyLevel, f => f.Random.Int(1, 10))
            .RuleFor(s => s.Description, f => f.Lorem.Sentence());

        var addressFaker = new Faker<Address>()
            .RuleFor(a => a.Street, f => f.Address.StreetAddress())
            .RuleFor(a => a.City, f => cityFaker.Generate()) // Generates a random city
            .RuleFor(a => a.PostalCode, f => f.Address.ZipCode());

        var contactFaker = new Faker<ContactInfo>()
            .RuleFor(c => c.Email, f => f.Internet.Email())
            .RuleFor(c => c.PhoneNumber, f => f.Phone.PhoneNumber());

        var employeeFaker = new Faker<Employee>()
            .RuleFor(e => e.Name, f => f.Name.FullName())
            .RuleFor(e => e.Age, f => f.Random.Int(20, 60))
            .RuleFor(e => e.EmploymentStatus, f => f.PickRandom<Status>())
            .RuleFor(e => e.HomeAddress, f => addressFaker.Generate())
            .RuleFor(e => e.Contact, f => contactFaker.Generate())
            .RuleFor(e => e.City, f => cityFaker.Generate())
            .RuleFor(e => e.Skills, f => skillFaker.Generate(5));

        // Generate a list of employees
        List<Employee> employees = employeeFaker.Generate(1_000_000);
        return employees;
    }

    private static byte[] PackEmployee() => MessagePackSerializer.Serialize(Employee);

    private static List<byte[]> PackEmployees()
    {
        List<byte[]> packedEmployees = [];
        foreach (var employee in Employees)
        {
            packedEmployees.Add(MessagePackSerializer.Serialize(employee));
        }
        return packedEmployees;
    }

    [Benchmark]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>")]
    public void SerializeUsingMessagePack() => _ = MessagePackSerializer.Serialize(Employee);

    [Benchmark]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>")]
    public void DeserializeUsingMessagePack() => _ = MessagePackSerializer.Deserialize<Employee>(EmployeePacked);

    [Benchmark]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>")]
    public void SerializeMillionArrayUsingMessagePack()
    {
        foreach (var employee in Employees)
        {
            MessagePackSerializer.Serialize(employee);
        }
    }

    [Benchmark]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>")]
    public void DeserializeMillionArrayUsingMessagePack()
    {
        foreach (var packedEmployee in EmployeesPacked)
        {
            MessagePackSerializer.Deserialize<Employee>(packedEmployee);
        }
    }
}
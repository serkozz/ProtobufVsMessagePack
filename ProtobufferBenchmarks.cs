using ProtobufVsMessagePack.ProtobufModel;
using BenchmarkDotNet.Attributes;
using Google.Protobuf;
using Bogus;

namespace ProtobufVsMessagePack;

[MemoryDiagnoser]
public class ProtobufferBenchmarks
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
        Employee employee = new()
        {
            City = moscow,
            Contact = new() { Email = "test@mail.ru", PhoneNumber = "12345678910" },
            HomeAddress = new()
            {
                City = moscow,
                Street = "Pushkina",
                PostalCode = "001"
            },
            Age = 23,
            EmploymentStatus = Status.Pending,
            Name = "name",
        };
        employee.Skills.Add([
            new() { Name = "C#", Description = "Seems good", ProficiencyLevel = 7},
            new() { Name = "CSS", Description = ":(", ProficiencyLevel = 3}
        ]);
        return employee;
    }

    private static byte[] PackEmployee() => Employee.ToByteArray();

    private static List<byte[]> PackEmployees()
    {
        List<byte[]> packedEmployees = [];
        foreach (var employee in Employees)
        {
            packedEmployees.Add(employee.ToByteArray());
        }
        return packedEmployees;
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
            .RuleFor(e => e.City, f => cityFaker.Generate());

        // Generate a list of employees
        List<Employee> employees = employeeFaker.Generate(1_000_000);
        foreach (var employee in employees)
        {
            employee.Skills.Add(skillFaker.Generate(5));
        }
        return employees;
    }

    [Benchmark]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>")]
    public void SerializeUsingProtobuffers() => _ = Employee.ToByteArray();

    [Benchmark]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>")]
    public void DeserializeUsingProtobuffers() => _ = Employee.Parser.ParseFrom(EmployeePacked);

    [Benchmark]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>")]
    public void SerializeMillionArrayUsingProtobuffers()
    {
        foreach (var employee in Employees)
        {
            employee.ToByteArray();
        }
    }

    [Benchmark]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "<Pending>")]
    public void DeserializeMillionArrayUsingProtobuffers()
    {
        foreach (var packedEmployee in EmployeesPacked)
        {
            Employee.Parser.ParseFrom(packedEmployee);
        }
    }
}
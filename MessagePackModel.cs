using MessagePack;

namespace ProtobufVsMessagePack.MessagePackModel;

public enum Status
{
    Active,
    Inactive,
    Pending
}

[MessagePackObject]
public class City
{
    [Key(0)]
    public required string Name { get; set; }
    [Key(1)]
    public required string State { get; set; }
    [Key(2)]
    public required string Country { get; set; }
    [Key(3)]
    public required int Population { get; set; }

    public override string ToString()
    {
        return $"{Name}, {State}, {Country} (Population: {Population})";
    }
}

[MessagePackObject]
public class Skill
{
    [Key(0)]
    public required string Name { get; set; }
    [Key(1)]
    public required int ProficiencyLevel { get; set; }
    [Key(2)]
    public required string Description { get; set; }

    public override string ToString()
    {
        return $"{Name} (Proficiency: {ProficiencyLevel}/10) - {Description}";
    }
}

[MessagePackObject]
public class ContactInfo
{
    [Key(0)]
    public required string Email { get; set; }
    [Key(1)]
    public required string PhoneNumber { get; set; }
}

[MessagePackObject]
public class Employee()
{
    [Key(0)]
    public required string Name { get; set; }
    [Key(1)]
    public required int Age { get; set; }
    [Key(2)]
    public Status EmploymentStatus { get; set; }
    [Key(3)]
    public required Address HomeAddress { get; set; }
    [Key(4)]
    public required ContactInfo Contact { get; set; }
    [Key(5)]
    public required List<Skill> Skills { get; set; } = [];
    [Key(6)]
    public required City City { get; set; }

    public void AddSkill(Skill skill)
    {
        Skills.Add(skill);
    }

    public override string ToString()
    {
        string skills = string.Join(", ", Skills);
        return $"{Name}, Age: {Age}, Status: {EmploymentStatus}, City: {City}, Skills: {skills}, Address: {HomeAddress}";
    }
}

[MessagePackObject]
public class Address()
{
    [Key(0)]
    public required string Street { get; set; }
    [Key(1)]
    public required City City { get; set; }
    [Key(2)]
    public required string PostalCode { get; set; }

    public override string ToString()
    {
        return $"{Street}, {City}, {PostalCode}";
    }
}
using crud_litedb.Models;
using crud_litedb.Repositories;

namespace crud_litedb.Services;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _personRepository;
    public PersonService(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public void AddPerson()
    {
        var person = FillPerson();
        if (person != null) _personRepository.AddPerson(person);
    }

    public void GetPersonById()
    {
        var id = GetId();
        if (id is null) return;
        var person = _personRepository.GetPersonById(id.Value);
        Console.WriteLine(person is not null ? person.ToString() : $"No person found with ID {id}");
        FlowPause();
    }

    public void GetAllPerson()
    {
        var persons = (_personRepository.GetAllPerson() ?? Array.Empty<Person>()).ToList();
        if (persons.Count == 0)
        {
            Console.WriteLine("No person found");
            FlowPause();
            return;
        }
        foreach (var person in persons.ToList())
        {
            Console.WriteLine($"{person}\n");
        }
        FlowPause();
    }

    public void UpdatePerson()
    {
        var id = GetId();
        if (id == null) return;
        var person = _personRepository.GetPersonById(id.Value);
        if (person is null)
        {
            Console.WriteLine($"No person found with ID {id}");
            FlowPause();
            return;
        }
        
        person = FillPerson(id.Value);
        if (person == null) return;
        var response = _personRepository.UpdatePerson(person);
        if (response) return;
        Console.WriteLine($"Error when trying to update person with id {id}");
        FlowPause();
    }

    public void DeletePerson()
    {
        var id = GetId();
        if (id is null) return;
        if (_personRepository.DeletePerson(id.Value)) return;
        Console.WriteLine($"Error when trying to delete person with id {id}");
        FlowPause();
    }

    private static Person? FillPerson(int id = 0)
    {
        Console.Write("Type a age: ");
        var inputAge = Console.ReadLine();
        if (!int.TryParse(inputAge, out var age))
        {
            Console.WriteLine("Invalid Age");
            FlowPause();
            return null;
        }
        Console.Write("Type a name: ");
        var name = Console.ReadLine();

        return new Person
        {
            Name = name,
            Age = age,
            Id = id
        };
    }

    private static int? GetId()
    {
        Console.Write("Type a Id: ");
        var inputId = Console.ReadLine();
        if (int.TryParse(inputId, out var id)) return id;
        Console.WriteLine("Invalid ID");
        FlowPause();
        return null;
    }

    private static void FlowPause()
    {
        Console.WriteLine("Type enter to continue...");
        Console.ReadLine();
    }
}
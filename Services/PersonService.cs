using crud_litedb.Models;
using crud_litedb.Repositories;

namespace crud_litedb.Services;

public class PersonService : IPersonService
{
    //adicionar pause nos metodos de fillPerson e get ID
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

    public void GetPerson()
    {
        var id = GetId();
        if (id == null) return;
        Console.WriteLine(_personRepository.GetPerson(id.Value)!.ToString());
        FlowPause();
    }

    public void GetAllPerson()
    {
        var persons = _personRepository.GetAllPerson();
        if (persons == null)
        {
            Console.WriteLine("No person found");
            FlowPause();
            return;
        }
        foreach (var person in persons.ToList())
        {
            Console.WriteLine(person.ToString());
        }
        FlowPause();
    }

    public void UpdatePerson()
    {
        var id = GetId();
        if (id == null) return;
        
        var person = FillPerson(id.Value);
        if (person == null) return;
        var response = _personRepository.UpdatePerson(person);
        if (response) return;
        Console.WriteLine($"Error when trying to update person with id {id}");
        FlowPause();
    }

    public void DeletePerson()
    {
        var id = GetId();
        if (id != null) _personRepository.DeletePerson(id.Value);
        else FlowPause();
    }

    private static Person? FillPerson(int id = 0)
    {
        Console.Write("Type a age: ");
        var inputAge = Console.ReadLine();
        if (int.TryParse(inputAge, out var age))
        {
            Console.WriteLine("Invalid Age");
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
        Console.WriteLine("Type enter to continue");
        Console.ReadLine();
    }
}
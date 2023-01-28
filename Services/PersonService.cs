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
        _personRepository.AddPerson();
    }

    public void GetPerson()
    {
        _personRepository.GetPerson();
    }

    public void GetAllPerson()
    {
        _personRepository.GetAllPerson()
    }

    public void UpdatePerson()
    {
        _personRepository.UpdatePerson();
    }

    public void DeletePerson()
    {
        _personRepository.DeletePerson();
    }
}
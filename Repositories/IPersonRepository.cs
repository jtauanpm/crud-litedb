using crud_litedb.Models;
using LiteDB;

namespace crud_litedb.Repositories;

public interface IPersonRepository
{
    public void AddPerson(Person person);

    public Person? GetPerson(int id);

    public IEnumerable<Person>? GetAllPerson();

    public void UpdatePerson(Person person);

    public void DeletePerson(int id);
}
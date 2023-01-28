using crud_litedb.Models;
using LiteDB;

namespace crud_litedb.Repositories;

public class PersonRepository : IPersonRepository
{
    public void AddPerson(Person person)
    {
        var db = CreateDb();
        db.GetCollection<Person>().Insert(person);
        db.Commit();
    }

    public Person? GetPerson(int id)
    {
        var db = CreateDb();
        return !db.CollectionExists("Person") ? null : db.GetCollection<Person>().FindOne(p => p.Id == id);
    }

    public IEnumerable<Person>? GetAllPerson()
    {
        var db = CreateDb();
        return !db.CollectionExists("Person") ? null : db.GetCollection<Person>().FindAll();
    }

    public void UpdatePerson(Person person)
    {
        var db = CreateDb();
        if (!db.CollectionExists("Person")) return;
        db.GetCollection<Person>().Update(person);
    }

    public void DeletePerson(int id)
    {
        var db = CreateDb();
        if (!db.CollectionExists("Person")) return;
        db.GetCollection<Person>().Delete(id);
    }
    
    private LiteDatabase CreateDb()
    {
        return new LiteDatabase("Data.db");
    }
}
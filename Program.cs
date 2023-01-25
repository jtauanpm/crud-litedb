// See https://aka.ms/new-console-template for more information

using LiteDB;

//AddPerson(new Person{Name = "Jonathan", Age = 19}, CreateDb());
//AddPerson(new Person{Name = "Fulano", Age = 30}, CreateDb());
//UpdatePerson(new Person{Name = "Ciclano", Age = 40, Id = 2}, CreateDb());
//GetPerson(1, CreateDb());
//DeletePerson(3, CreateDb());
//GetAllPerson(CreateDb());

static LiteDatabase CreateDb()
{
    return new LiteDatabase("Data.db");
}

static void AddPerson(Person person, LiteDatabase db)
{
    db.GetCollection<Person>().Insert(person);
    db.Commit();
}

static void GetPerson(int id, LiteDatabase db)
{
    if (!db.CollectionExists("Person")) return;
    var person = db.GetCollection<Person>().FindOne(p => p.Id == id);
    Console.WriteLine(person.ToString());
}

static void GetAllPerson(LiteDatabase db)
{
    if (!db.CollectionExists("Person")) return;
    var people = db.GetCollection<Person>().FindAll().ToList();
    foreach (var person in people)
    {
        Console.WriteLine(person.ToString());
    }
}

static void UpdatePerson(Person person, LiteDatabase db)
{
    if (!db.CollectionExists("Person")) return;
    db.GetCollection<Person>().Update(person);
}

static void DeletePerson(int id, LiteDatabase db)
{
    if (!db.CollectionExists("Person")) return;
    db.GetCollection<Person>().Delete(id);
}

public class Person
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }

    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}, Id: {Id}";
    }
}
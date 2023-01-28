using crud_litedb.Repositories;
using crud_litedb.Services;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();
ConfigureServices(serviceCollection);

var serviceProvider = serviceCollection.BuildServiceProvider();
var personService = serviceProvider.GetService<IPersonService>();

Menu();


//AddPerson(new Person{Name = "Jonathan", Age = 19}, CreateDb());
//AddPerson(new Person{Name = "Fulano", Age = 30}, CreateDb());
//UpdatePerson(new Person{Name = "Ciclano", Age = 40, Id = 2}, CreateDb());
//GetPerson(1, CreateDb());
//DeletePerson(3, CreateDb());
//GetAllPerson(CreateDb());

void ConfigureServices(IServiceCollection service)
{
    service
        .AddScoped<IPersonRepository, PersonRepository>()
        .AddScoped<IPersonService, PersonService>();
    
}

void Menu()
{
    Console.WriteLine("Type a number:" +
                      "1 - AddPerson" +
                      "2 - GetPerson" +
                      "3 - GetAllPerson" +
                      "4 - UpdatePerson" +
                      "5 - DeletePerson");
    var choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            personService!.AddPerson();
            break;
        case "2":
            personService!.GetPerson();
            break;
        case "3":
            personService!.GetAllPerson();
            break;
        case "4":
            personService!.UpdatePerson();
            break;
        case "5":
            personService!.DeletePerson();
            break;
    }
}
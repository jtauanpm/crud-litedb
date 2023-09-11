using crud_litedb.Models;
using crud_litedb.Repositories;
using crud_litedb.Services;
using Moq;
using Xunit;

namespace crud_litedb.UnitTests;

public class PersonServiceTests
{
    [Fact]
    public void AddPerson_Should_Call_AddPerson_In_Repository()
    {
        // Arrange
        var personRepositoryMock = new Mock<IPersonRepository>();
        var personService = new PersonService(personRepositoryMock.Object);
        
        // Act
        personService.AddPerson();

        // Assert
        personRepositoryMock.Verify(repo => 
            repo.AddPerson(It.IsAny<Person>()), Times.Once);
        personRepositoryMock.VerifyNoOtherCalls();
    }

    [Fact]
    public void GetPersonById_Should_Call_GetPersonById_In_Repository()
    {
        // Arrange
        var id = 1;
        var personRepositoryMock = new Mock<IPersonRepository>();
        personRepositoryMock.Setup(repo => 
            repo.GetPersonById(id)).Returns(new Person { Id = id }); // Mock the repository's behavior
        var personService = new PersonService(personRepositoryMock.Object);
        
        // Act
        personService.GetPersonById();

        // Assert
        personRepositoryMock.Verify(repo => 
            repo.GetPersonById(id), Times.Once);
        personRepositoryMock.VerifyNoOtherCalls();
    }

    [Fact]
    public void GetAllPerson_Should_Write_Persons_To_Console()
    {
        // Arrange
        var persons = new List<Person>
        {
            new Person { Id = 1, Name = "John", Age = 30 },
            new Person { Id = 2, Name = "Paul", Age = 25 }
        };
        var personRepositoryMock = new Mock<IPersonRepository>();
        personRepositoryMock.Setup(repo => 
            repo.GetAllPerson()).Returns(persons);
        var personService = new PersonService(personRepositoryMock.Object);
        
        // Act
        personService.GetAllPerson();

        // Assert
        personRepositoryMock.Verify(repo => repo.GetAllPerson(), Times.Once);
        personRepositoryMock.VerifyNoOtherCalls();
    }

    [Fact]
    public void UpdatePerson_Should_Call_GetPersonById_And_UpdatePerson_In_Repository()
    {
        // Arrange
        var id = 1;
        var person = new Person { Id = id, Name = "George", Age = 30 };
        var personRepositoryMock = new Mock<IPersonRepository>();
        personRepositoryMock.Setup(repo => 
            repo.GetPersonById(id)).Returns(person);
        var personService = new PersonService(personRepositoryMock.Object);
        
        // Act
        personService.UpdatePerson();

        // Assert
        personRepositoryMock.Verify(repo =>
            repo.GetPersonById(id), Times.Once);
        personRepositoryMock.Verify(repo => 
            repo.UpdatePerson(person), Times.Once);
        personRepositoryMock.VerifyNoOtherCalls();
    }

    [Fact]
    public void DeletePerson_Should_Call_DeletePerson_In_Repository()
    {
        // Arrange
        var id = 1;
        var personRepositoryMock = new Mock<IPersonRepository>();
        var personService = new PersonService(personRepositoryMock.Object);
        
        // Act
        personService.DeletePerson();

        // Assert
        personRepositoryMock.Verify(repo =>
            repo.DeletePerson(id), Times.Once);
    }
}

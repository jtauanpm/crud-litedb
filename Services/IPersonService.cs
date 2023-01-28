using crud_litedb.Models;

namespace crud_litedb.Services;

public interface IPersonService
{
    public void AddPerson();

    public void GetPerson();

    public void GetAllPerson();

    public void UpdatePerson();

    public void DeletePerson();
}
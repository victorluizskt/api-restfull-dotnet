using System.Collections.Generic;
using api_restful.Controllers.Model;

namespace api_restful.Repository.Implementations
{
    public interface IPersonRepository
    {
        Person Create(Person person);

        Person FindById(long id);

        Person Update(Person person);

        void Delete(long id);

        List<Person> FindAll();

        bool Exists(long id);
    }
}
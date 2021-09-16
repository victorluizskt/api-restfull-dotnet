using System.Collections.Generic;
using api_restful.Controllers.Model;

namespace api_restful.Services.Implementations
{
    public interface IPersonService
    {
        Person Create(Person person);

        Person FindById(long id);

        Person Update(Person person);

        void Delete(long id);

        List<Person> FindAll();
    }
}

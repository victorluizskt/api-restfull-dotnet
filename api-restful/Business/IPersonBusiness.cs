using System.Collections.Generic;
using api_restful.Controllers.Model;

namespace api_restful.Business.Implementations
{
    public interface IPersonBusiness
    {
        Person Create(Person person);

        Person FindById(long id);

        Person Update(Person person);

        void Delete(long id);

        List<Person> FindAll();
    }
}

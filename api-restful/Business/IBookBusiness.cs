using System.Collections.Generic;
using api_restful.Controllers.Model;

namespace api_restful.Business.Implementations
{
    public interface IBookBusiness
    {
        Book Create(Book person);

        Book FindById(int id);

        Book Update(Book person);

        void Delete(int id);

        List<Book> FindAll();
    }
}

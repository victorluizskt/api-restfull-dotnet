using System.Collections.Generic;
using api_restful.Controllers.Model;

namespace api_restful.Repository.Implementations
{
    public interface IBookRepository
    {
        Book Create(Book book);

        Book FirstById(int id);

        Book Update(Book book);

        void Delete(int id);

        List<Book> FindAll();
    }
}

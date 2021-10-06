using System.Collections.Generic;
using api_restful.Controllers.Model;
using api_restful.Repository.Implementations;

namespace api_restful.Business.Implementations
{
    public class BookBusinessImplementation : IBookBusiness
    {

        private readonly IBookRepository _repository;

        public BookBusinessImplementation(IBookRepository repository)
        {
            _repository = repository;
        }

        public Book Create(Book person)
        {
            return _repository.Create(person);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }

        public Book FindById(int id)
        {
            return _repository.FirstById(id);
        }

        public Book Update(Book person)
        {
            return _repository.Update(person);
        }
    }
}

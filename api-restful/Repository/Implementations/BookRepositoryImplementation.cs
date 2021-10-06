using System;
using System.Collections.Generic;
using System.Linq;
using api_restful.Controllers.Model;
using api_restful.Model.Context;

namespace api_restful.Repository.Implementations
{
    public class BookRepositoryImplementation : IBookRepository
    {
        private MySQLContext _context;

        public BookRepositoryImplementation(MySQLContext context)
        {
            _context = context;
        }

        #region
        public Book Create(Book book)
        {
            try
            {
                _context.Add(book);
                if(book != null)
                {
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return book;
        }

        public void Delete(int id)
        {
            var result = Search(id);

            if(result != null)
            {
                try
                {
                    _context.Book.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<Book> FindAll()
        {
            return _context.Book.ToList();
        }

        public Book FirstById(int id)
        {
            return Search(id);
        }

        public Book Update(Book book)
        {
            if (Search(book.Id) == null) return null;

            var result = Search(book.Id);

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(book);
                    if (book != null)
                    {
                        _context.SaveChanges();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return book;
        }
        #endregion

        private Book Search(int id)
        {
            return _context.Book.SingleOrDefault(p => p.Equals(id));
        }
    }
}

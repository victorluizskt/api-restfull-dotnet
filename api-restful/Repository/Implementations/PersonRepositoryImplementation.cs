using System;
using System.Collections.Generic;
using System.Linq;
using api_restful.Controllers.Model;
using api_restful.Model.Context;

namespace api_restful.Repository.Implementations
{
    public class PersonRepositoryImplementation : IPersonRepository
    { 
        private MySQLContext _context;

        public PersonRepositoryImplementation(MySQLContext context)
        { 
            _context = context;
        }

        #region
        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                if (person != null)
                {
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return person;
        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return null;

            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    if (person != null)
                    {
                        _context.SaveChanges();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return person;
        }

        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        #endregion

        public bool Exists(long id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }
    }
}

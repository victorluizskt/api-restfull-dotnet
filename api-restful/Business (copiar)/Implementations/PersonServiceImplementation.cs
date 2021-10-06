using System;
using System.Collections.Generic;
using System.Linq;
using api_restful.Controllers.Model;
using api_restful.Model.Context;

namespace api_restful.Business.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private MySQLContext _context;

        public PersonServiceImplementation(MySQLContext context)
        {
            _context = context;
        }

        #region
        public List<Person> FindAll()
        {
            return _context.persons.ToList();
        }

        public Person FindById(long id)
        {
            return _context.persons.SingleOrDefault(p => p.Id.Equals(id));
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
            if (!Exists(person.Id)) return new Person();

            var result = _context.persons.SingleOrDefault(p => p.Id.Equals(person.Id));

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
            var result = _context.persons.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.persons.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
        #endregion

        private bool Exists(long id)
        {
            return _context.persons.Any(p => p.Id.Equals(id));
        }
    }
 }

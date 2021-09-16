using System;
using System.Collections.Generic;
using System.Threading;
using api_restful.Controllers.Model;

namespace api_restful.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new();

            for(int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

        public Person FindById(long id)
        {
            return new Person
            {
                Id = 1,
                FirstName = "Victor",
                LastName = "Luiz",
                Address = "Timóteo - Minas Gerais, Brazil",
                Gender = "Male",
            };
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncremendAndGet(),
                FirstName = "Person name" + i,
                LastName = "Person Last Name" + i,
                Address = "Some Adress" + i,
                Gender = "Male" + i,
            };
        }

        private long IncremendAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Domain;

namespace Application.Person
{
    public class GetPeopleQuery : IGetPeopleQuery
    {
        private readonly FunctionsDbContext _context;

        public GetPeopleQuery(FunctionsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PersonDto>> Execute()
        {
            return await _context.Persons.Select(PersonDto.Projection).ToListAsync();
        }
    }

    public interface IGetPeopleQuery
    {
        Task<IEnumerable<PersonDto>> Execute();
    }

    public class PersonDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public static Expression<Func<Domain.Person, PersonDto>> Projection => p => new PersonDto
        {
            DateOfBirth = p.DateOfBirth,
            FirstName = p.Firstname,
            LastName = p.Lastname
        };
    }
}
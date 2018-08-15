using System;
using Domain;

namespace Persistence
{
    public static class SeedHelpers
    {
        public static void CreatePerson(this FunctionsDbContext context, string firstname, string lastname, DateTime dateOfBirth)
        {
            context.Persons.Add(new Person
            {
                DateOfBirth = dateOfBirth,
                Firstname = firstname,
                Lastname = lastname
            });
        }
    }
}
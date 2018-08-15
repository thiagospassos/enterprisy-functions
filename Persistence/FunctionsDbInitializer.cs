using System;

namespace Persistence
{
    public class FunctionsDbInitializer
    {
        private readonly FunctionsDbContext _context;

        public FunctionsDbInitializer(FunctionsDbContext context)
        {
            _context = context;
        }

        public FunctionsDbInitializer Initialize()
        {
            _context.Database.EnsureCreated();
            return this;
        }

        public FunctionsDbInitializer Seed()
        {
            _context.CreatePerson("Thiago", "Passos", DateTime.Now.AddYears(-20));
            _context.CreatePerson("Alyne", "Gomes", DateTime.Now.AddYears(-22));
            _context.CreatePerson("John", "Doe", DateTime.Now.AddYears(-24));
            _context.CreatePerson("Jack", "Smith", DateTime.Now.AddYears(-26));
            _context.CreatePerson("Mary", "Smith", DateTime.Now.AddYears(-28));
            _context.CreatePerson("Joao", "Passos", DateTime.Now.AddYears(-30));
            _context.SaveChanges();
            return this;
        }
    }
}
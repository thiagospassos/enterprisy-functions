using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Persistence;

namespace Application.Person
{
    public class AddRandomPersonCommand : IAddRandomPersonCommand
    {
        private readonly FunctionsDbContext _context;

        public AddRandomPersonCommand(FunctionsDbContext context)
        {
            _context = context;
        }

        public async Task<PersonDto> Execute()
        {
            var names = new List<string>()
            {
                "Adelaide", "Adeline", "Alice", "Amelia", "Arthur", "Atticus", "Audrey", "Aurelia", "Aurora",
                "Beatrice", "Caleb", "Charlotte", "Chloe", "Clara", "Clementine", "Cora", "Eleanor", "Eli", "Eliza",
                "Eloise", "Emilia", "Emma", "Emmeline", "Esme", "Evangeline", "Evelyn", "Gabriel", "Grace", "Harrison",
                "Hazel", "Henry", "Iris", "Isabella", "Isaiah", "Jane", "Jasper", "Jonah", "Josephine", "Josiah", "Levi",
                "Lily", "Lucy", "Lydia", "Maisie", "Margaret", "Maxwell", "Nathan", "Nathaniel", "Oliver", "Olivia",
                "Oscar", "Penelope", "Roman", "Rose", "Sadie", "Samuel", "Sebastian", "Silas", "Sophia", "Thea",
                "Theodore", "Tobias", "Violet", "Wyatt"
            };

            var surnames = new List<string>()
            {
                "Smith", "Jones", "Taylor", "Williams", "Brown", "Davies", "Evans", "Wilson", "Thomas", "Roberts",
                "Johnson", "Lewis", "Walker", "Robinson", "Wood", "Thompson", "White", "Watson", "Jackson", "Wright",
                "Green", "Harris", "Cooper", "King", "Lee", "Martin", "Clarke", "James", "Morgan", "Hughes", "Edwards",
                "Hill", "Moore", "Clark", "Harrison", "Scott", "Young", "Morris", "Hall", "Ward", "Turner", "Carter",
                "Phillips", "Mitchell", "Patel", "Adams", "Campbell", "Anderson", "Allen", "Cook"
            };

            var rand = new Random();
            var firstnameIndex = rand.Next(0, names.Count);
            var lastnameIndex = rand.Next(0, surnames.Count);
            var daysOld = rand.Next(7300, 18250);


            var person = new Domain.Person
            {
                DateOfBirth = DateTime.Now.AddDays(-daysOld),
                Firstname = names[firstnameIndex],
                Lastname = surnames[lastnameIndex]
            };

            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
            return PersonDto.Projection.Compile().Invoke(person);
        }
    }

    public interface IAddRandomPersonCommand
    {
        Task<PersonDto> Execute();
    }
}
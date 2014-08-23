using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scripts
{
    public class Engine
    {
        public Engine(List<Person> people)
        {
            this.people = people;
        }

        public PersonSelection NextPossiblePeople()
        {
            return new PersonSelection(
                    people
                        .Select(t => new { Person = t, Dialogs = t.DialogTrees.Where(u => u.IsAvailable(context)) })
                        .Where(t => t.Dialogs.FirstOrDefault() != null)
                        .RandomItems(random, 3)
                        .Select(t => new PersonSelectionOption() { Person = t.Person, DialogTree = t.Dialogs.RandomItems(random, 1).First() })
                        .ToList()
                );
        }

        public DialogEngine AcceptDialogEntry(PersonSelection dialogs, PersonSelectionOption person)
        {
            return new DialogEngine(person, context);
        }

        private const uint dialogCount = 3;
        private Context context = new Context();
        private Random random = new Random();
        private List<Person> people;
    }
}

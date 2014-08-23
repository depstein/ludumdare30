using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scripts
{
    public class PersonSelection
    {
        public PersonSelection(List<PersonSelectionOption> people)
        {
            People = people;
        }

        public List<PersonSelectionOption> People { get; private set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scripts
{
    public class DialogEngine
    {
        public DialogEngine(PersonSelectionOption person, Context context)
        {
            this.person = person;
            this.context = context;
            this.CurrentStatement = person.DialogTree.RootStatement;
        }

        public void TakeOption(string option)
        {
            DialogOption selectedOption = this.CurrentStatement.Answers.First(t => t.Response == option);
            this.context.PromptUsed(person, CurrentStatement, selectedOption);
            this.CurrentStatement = selectedOption.Statement;
        }

        private Context context;
        private PersonSelectionOption person;
        public DialogNode CurrentStatement { get; private set; }
    }
}

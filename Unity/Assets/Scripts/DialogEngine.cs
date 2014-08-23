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
            this.CurrentNode = person.DialogTree.RootNode;
        }

        public void TakeOption(string option)
        {
            this.context.PromptUsed(person, CurrentNode, option);
            this.CurrentNode = this.CurrentNode.Answers.First(t => t.Key==option).Value;
        }

        private Context context;
        private PersonSelectionOption person;
        public DialogNode CurrentNode { get; private set; }
    }
}

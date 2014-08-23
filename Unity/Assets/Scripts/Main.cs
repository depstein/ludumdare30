using UnityEngine;
using System.Collections;
using System;
using System.Linq;

namespace Scripts
{
    public class Main : MonoBehaviour
    {

        private Engine engine;
        public GUI.PersonUI[] People;
        public GUI.OptionUI[] Options;
        public GUI.ContinueUI Continue;

        void Start()
        {
            engine = new Engine(XmlLoading.ReadFolderOfPeople());
            ShowPeopleSelection();
        }

        void ShowPeopleSelection()
        {
            Options.ForEach(t => t.Hide());
            People.ForEach(t => t.Hide());
            var selection = engine.NextPossiblePeople();
            selection.People.ForEach((t, i) => People[i].ShowThoughtBubble(t, () => PersonSelected(People[i], selection, t)));
        }

        void PersonSelected(GUI.PersonUI person, PersonSelection selection, PersonSelectionOption personSelected)
        {
            var dialogEngine = engine.AcceptDialogEntry(selection, personSelected);

            People.Where(t => t != person).ForEach(t => t.Hide());

            RunDialog(dialogEngine, person);
        }

        void TakeOption(DialogEngine dialogEngine, GUI.PersonUI person, string option)
        {
            dialogEngine.TakeOption(option);
            RunDialog(dialogEngine, person);
        }

        void RunDialog(DialogEngine dialogEngine, GUI.PersonUI person)
        {
            person.ShowSpeechBubble(dialogEngine.CurrentStatement);

            if (dialogEngine.CurrentStatement.Type == DialogType.Terminal)
            {
                Options.ForEach(t => t.Hide());
                Continue.Show(() => ShowPeopleSelection());
                return;
            }

            var answers = dialogEngine.CurrentStatement.Answers;

            Options.ForEach((t, i) =>
                {
                    if (i < answers.Count)
                        t.Show(answers[i].Response, () => TakeOption(dialogEngine, person, answers[i].Response));
                    else
                        t.Hide();
                });
        }
    }
}
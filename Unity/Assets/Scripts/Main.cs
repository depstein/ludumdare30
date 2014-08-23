using UnityEngine;
using System.Collections;


namespace Scripts {


	public class Main : MonoBehaviour {
		
		public Engine engine;
		public DialogEngine dialogEngine;

		private PersonSelection selection;


		// Use this for initialization
		void Start () {
			engine = new Engine (XmlLoading.ReadFolderOfPeople());
			ShowPeopleSelection ();
		}

		void ShowPeopleSelection()
		{
			selection = engine.NextPossiblePeople ();

			// selection.People[0].Person.Name
			// selection.People[0].DialogTree.Hint

			BasicButtonClick button0 = null; /// .....

			button0.function = 
				() =>
				{
					// Hide buttons above
					SelectPerson (selection.People [0]);
				};
		}

		void ShowPerson(PersonSelectionOption selectionOption)
		{

		}

		void SelectPerson(PersonSelectionOption person)
		{
			dialogEngine = engine.AcceptDialogEntry (selection, person);
			selection = null;

			ShowNode ();
		}

		void ShowNode()
		{

			// dialogEngine.CurrentNode.Prompt

			if (dialogEngine.CurrentNode.Type == DialogType.Terminal)
			{
				// show ok button
				
				BasicButtonClick button0 = null; /// .....
				
				button0.function = 
					() => 
					{ 
						// remove prompt/answer above
						ShowPeopleSelection();
					}
			}
			else
			{
				// dialogEngine.CurrentNode.Answers
				
				BasicButtonClick button0 = null; /// .....
				
				button0.function = 
					() => 
					{ 
						// remove prompt/answer above
						dialogEngine.TakeOption(dialogEngine.CurrentNode.Answers[0].Value); 
						ShowNode();
					};
			}

		}
		
		// Update is called once per frame
		void Update () {
		
		}
	}


}
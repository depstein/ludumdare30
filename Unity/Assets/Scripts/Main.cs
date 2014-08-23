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

			for (int x = 0; x < selection.People.Count; x++)
			{
				SetButton (selection, x);
				ShowPerson (selection, x);
			}
			// selection.People[0].Person.Name
			// selection.People[0].DialogTree.Hint

/*			BasicButtonClick button0 = null; /// .....

			button0.function = 
				() =>
				{
					// Hide buttons above
					SelectPerson (selection.People [0]);
				};*/
		}

		void SetButton(PersonSelection selection, int index)
		{
			GameObject personObject = GameObject.Find ("Person "+index);
			BasicButtonClick clickScript = personObject.GetComponent<BasicButtonClick> ();
			clickScript.function = () => 
			{
				// Hide buttons above
				SelectPerson (selection.People [index]); 
			};
		}

		void ShowPerson(PersonSelection selection, int index)
		{
			PersonSelectionOption selectionOption = selection.People[index];

			GameObject personObject = GameObject.Find ("Person "+index);
			UILabel[] labels = personObject.GetComponents<UILabel>();
			foreach (UILabel label in labels)
			{
				if (label.name.Equals("LabelName"))
				{
					label.text = selectionOption.Person.Name;
				}
				else if (label.name.Equals ("LabelHint"))
				{
					label.text = "I'd like a drink";
				}
			}
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

			/*if (dialogEngine.CurrentNode.Type == DialogType.Terminal)
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
			}*/

		}
		
		// Update is called once per frame
		void Update () {
		
		}
	}


}
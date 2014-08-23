using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace Scripts {


	public class Main : MonoBehaviour {
		
		public Engine engine;
		public DialogEngine dialogEngine;

		private PersonSelection selection;
		public UILabel[] options;

		// Use this for initialization
		void Start () {
			List<Person> people = XmlLoading.ReadFolderOfPeople();
			foreach(Person p in people) {
				Debug.Log(p);
			}
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
				HidePeople ();
				SelectPerson (selection.People [index]); 
			};
		}

		void HidePeople()
		{
			for (int x = 0; x < 3; x++)
			{
				GameObject person = GameObject.Find ("Person " + x);
				var personObject = person.GetComponent<UIPerson>();
				personObject.SetHintUIVisibility(false);
			}
		}

		void ShowPerson(PersonSelection selection, int index)
		{
			PersonSelectionOption selectionOption = selection.People[index];

			GameObject person = GameObject.Find ("Person " + index);
			var personObject = person.GetComponent<UIPerson>();
			personObject.SetHintUIVisibility(true);

			personObject.name.text = selectionOption.Person.Name;
			personObject.hint.text = selectionOption.DialogTree.Hint;
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
				for (int x = 0; x < options.Length; x++)
				{
					options[x].gameObject.SetActive(false);
				}
				ShowPeopleSelection();
				// show ok button
				
				/*BasicButtonClick button0 = null; /// .....
				
				button0.function = 
					() => 
					{ 
						// remove prompt/answer above
						ShowPeopleSelection();
					}*/
			}
			else
			{
				// dialogEngine.CurrentNode.Answers

				for (int x = 0; x < options.Length; x++)
				{
					if (x < dialogEngine.CurrentNode.Answers.Count)
					{
						options[x].text = dialogEngine.CurrentNode.Answers[x].Key;
						options[x].gameObject.SetActive(true);

						BasicButtonClick clickScript = options[x].GetComponent<BasicButtonClick> ();
						int chosenOption = x;
						clickScript.function = 
							() => 
							{ 
								// remove prompt/answer above
								dialogEngine.TakeOption(dialogEngine.CurrentNode.Answers[chosenOption].Key); 
								ShowNode();
							};
					}
					else
					{
						options[x].gameObject.SetActive(false);
					}
				}

				/*BasicButtonClick button0 = null; /// .....
				
				button0.function = 
					() => 
					{ 
						// remove prompt/answer above
						dialogEngine.TakeOption(dialogEngine.CurrentNode.Answers[0].Value); 
						ShowNode();
					};*/
			}

		}
		
		// Update is called once per frame
		void Update () {
		
		}
	}


}
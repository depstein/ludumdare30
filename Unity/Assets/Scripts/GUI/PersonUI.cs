using UnityEngine;
using System.Collections;
using System;

namespace Scripts.GUI
{
    public class PersonUI : MonoBehaviour
    {
        public UILabel Hint;
        public ButtonUI Button;
		public GameObject ThoughtBubble;

        public void DisplayOptionUI(PersonSelectionOption person, Action selected)
        {
            Hint.gameObject.SetActive(true);
            Hint.text = person.DialogTree.Hint;
            Button.Click = selected;
			ThoughtBubble.SetActive (true);
        }

        internal void HideOptionUI()
        {
            Hint.gameObject.SetActive(false);
			ThoughtBubble.SetActive(false);
        }
    }


}
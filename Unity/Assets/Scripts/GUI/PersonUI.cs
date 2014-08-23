using UnityEngine;
using System.Collections;
using System;

namespace Scripts.GUI
{
    public class PersonUI : MonoBehaviour
    {
        public GameObject ThoughtBubble;
        public UILabel ThoughtBubbleText;

        public GameObject SpeechBubble;
        public UILabel SpeechBubbleText;

        public ButtonUI Button;

        enum State
        {
            Hidden,
            Thoughts,
            Speech
        }

        public void ShowThoughtBubble(PersonSelectionOption person, Action selected)
        {
            GoToState(State.Thoughts, person.DialogTree.Hint, selected);
        }

        public void ShowSpeechBubble(DialogNode node)
        {
            GoToState(State.Speech, node.Prompt);
        }

        internal void Hide()
        {
            GoToState(State.Hidden);
        }

        private void GoToState(State state, string text = null, Action click = null)
        {
            SpeechBubble.SetActive(state == State.Speech);
            ThoughtBubble.SetActive(state == State.Thoughts);
            Button.Click = state == State.Speech ? click : null;
            ThoughtBubbleText.text = state == State.Thoughts ? text : null;
            SpeechBubbleText.text = state == State.Speech ? text : null;
        }
    }


}
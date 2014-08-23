using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Scripts.GUI
{
    public class OptionUI : MonoBehaviour
    {

        public UILabel UILabel;
        public ButtonUI Button;

        internal void Hide()
        {
            gameObject.SetActive(false);
        }

        internal void Show(string option, Action selected)
        {
            UILabel.text = option;
            gameObject.SetActive(true);
            Button.Click = selected;
        }
    }
}

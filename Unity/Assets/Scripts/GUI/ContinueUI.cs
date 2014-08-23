using UnityEngine;
using System.Collections;
using System;

namespace Scripts.GUI
{
    public class ContinueUI : MonoBehaviour
    {
        public ButtonUI Button;

        public void Show(Action action)
        {
            gameObject.SetActive(true);
            Button.Click = () => { gameObject.SetActive(false); action(); };
        }
    }

}
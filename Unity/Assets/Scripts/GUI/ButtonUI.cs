using System;
using UnityEngine;

public class ButtonUI : MonoBehaviour
{
    public Action Click { get; set; }

    private void OnClick()
    {
        if (Click != null)
            Click();
    }

}

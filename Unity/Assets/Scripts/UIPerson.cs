using UnityEngine;
using System.Collections;

public class UIPerson : MonoBehaviour {

	public UILabel hint;
	public UILabel name;

	public void SetHintUIVisibility(bool vis)
	{
		hint.gameObject.SetActive (vis);
		name.gameObject.SetActive (vis);
	}
}

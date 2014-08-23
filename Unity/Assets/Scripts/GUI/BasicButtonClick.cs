using UnityEngine;

public class BasicButtonClick : MonoBehaviour {
	public delegate void Action ();

	public Action function { get; set; }

	void OnClick ()
	{
		if (function != null)
			function ();

		//UILabel c = GameObject.Find ("Label (btn Text)").GetComponent<UILabel> ();
	}
}

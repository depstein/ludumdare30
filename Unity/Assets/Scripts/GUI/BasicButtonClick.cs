using UnityEngine;

public class BasicButtonClick : MonoBehaviour {
	public Function function { get; set; }

	void OnClick ()
	{
		if (function != null)
			function ();

		//UILabel c = GameObject.Find ("Label (btn Text)").GetComponent<UILabel> ();
	}
}

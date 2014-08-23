using UnityEngine;

public class BasicButtonClick : MonoBehaviour {

	int count=0;
	void OnClick ()
	{
		print ("CLICKING");
		UILabel c = GameObject.Find ("Label (btn Text)").GetComponent<UILabel> ();
		c.text = "You have killed " + count + " grues";
		count++;
	}
}

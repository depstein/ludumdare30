using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {
	public GameObject background;
	private Color color1 = Colors.GetRandomColor();
	private Color color2 = Colors.GetRandomColor();
	private bool oneTwo = false;
	private const float frequency = 5f;

	// Use this for initialization
	void Start () {
		InvokeRepeating("ChangeColor", frequency, frequency);
	}
	
	// Update is called once per frame
	void Update () {
		float timeModded = (Time.time % frequency)/frequency;
		background.GetComponent<SpriteRenderer>().color = Color.Lerp(color1, color2, oneTwo?timeModded:1-timeModded);
	}

	void ChangeColor() {
		oneTwo = !oneTwo;
		if(oneTwo) {
			color2 = NextColor(color1);
		} else {
			color1 = NextColor(color2);
		}
	}

	Color NextColor(Color current) {
		float h, s, v;
		Colors.ColorToHSV(Colors.GetRandomColor(), out h, out s, out v);
		return Colors.ColorFromHSV(h, s, v, 1f);
	}
}
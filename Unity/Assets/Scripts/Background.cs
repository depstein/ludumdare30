using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {
	public GameObject background;
	private Color color1 = Colors.White;
	private Color color2 = Colors.White;
	private Color[] destinations = {Colors.GreenYellow, Colors.NeonGreen, Colors.BrightPink, Colors.Lemon, 
		Colors.SpiroDiscoBall, Colors.Ruddy, Colors.PurplePizzazz, Colors.Celeste, Colors.White};
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
		Color next = destinations[Utility.random.Next(destinations.Length)];
		while(next == current) {
			next = destinations[Utility.random.Next(destinations.Length)];
		}
		return next;
	}
}
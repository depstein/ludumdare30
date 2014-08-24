using UnityEngine;
using System.Collections;

public class Nebula : MonoBehaviour {
	private Color color1 = Colors.White;
	private Color color2 = Colors.White;
	private Color[] destinations = {Colors.GreenYellow, Colors.NeonGreen, Colors.BrightPink, Colors.Lemon, 
		Colors.SpiroDiscoBall, Colors.Ruddy, Colors.PurplePizzazz, Colors.Celeste, Colors.White};
	private bool oneTwo = false;
	private float colorFrequency;
	private float rotationMultiplier;

	// Use this for initialization
	void Start () {
		colorFrequency = Random.Range(2f, 8f);
		rotationMultiplier = Random.Range(5f, 10f) * (Random.value > 0.5 ? 1 : -1);
		InvokeRepeating("ChangeColor", colorFrequency, colorFrequency);
	}
	
	// Update is called once per frame
	void Update () {
		float timeModded = (Time.time % colorFrequency)/colorFrequency;
		this.GetComponent<SpriteRenderer>().color = Color.Lerp(color1, color2, oneTwo?timeModded:1-timeModded);
		transform.Rotate(Vector3.forward * Time.deltaTime * rotationMultiplier);
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
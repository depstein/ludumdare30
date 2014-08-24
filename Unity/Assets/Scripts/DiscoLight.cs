using UnityEngine;
using System.Collections;

public class DiscoLight : MonoBehaviour {
	private Color color1 = new Color(1f, 1f, 1f, 0.5f);
	private Color color2 = new Color(1f, 1f, 1f, 0.5f);
	private bool oneTwo = false;
	private float colorFrequency;
	private float rotationMultiplier;
	private float alpha;
	private float prevTime;

	// Use this for initialization
	void Start () {
		colorFrequency = Random.Range(2f, 8f);
		rotationMultiplier = Random.Range(5f, 10f) * (Random.value >= 0.5 ? 1 : -1);
		alpha = Random.Range(.1f, .5f);
	}
	
	// Update is called once per frame
	void Update () {
		float timeModded = (Time.time % colorFrequency)/colorFrequency;
		if(timeModded<prevTime) {
			ChangeColor();
		}

		this.GetComponent<SpriteRenderer>().color = Color.Lerp(color1, color2, oneTwo?timeModded:1-timeModded);
		transform.Rotate(Vector3.forward * Time.deltaTime * rotationMultiplier);
		prevTime = timeModded;
	}

	void ChangeColor() {
		oneTwo = !oneTwo;
		if(oneTwo) {
			color2 = NextColor();
		} else {
			color1 = NextColor();
		}
	}

	Color NextColor() {
		float h, s, v;
		Colors.ColorToHSV(Colors.GetRandomColor(), out h, out s, out v);
		return Colors.ColorFromHSV(h, 0.3f, v, alpha);
	}
}
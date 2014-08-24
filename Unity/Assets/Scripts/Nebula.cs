using UnityEngine;
using System.Collections;

public class Nebula : MonoBehaviour {
	private Color color1 = Colors.GetRandomColor();
	private Color color2 = Colors.GetRandomColor();
	private bool oneTwo = false;
	private float colorFrequency;
	private float rotationMultiplier;
	private float alpha;
	private Vector3 movement;
	private float prevTime;

	// Use this for initialization
	void Start () {
		color1.a = 0.5f;
		color2.a = 0.5f;
		colorFrequency = Random.Range(2f, 8f);
		rotationMultiplier = Random.Range(5f, 10f) * (Random.value >= 0.5 ? 1 : -1);
		alpha = Random.Range(.1f, .5f);
		Vector2 move = Random.insideUnitCircle * Random.Range(0.001f, 0.05f) * (Random.value >= 0.5 ? 1 : -1);
		movement = new Vector3(move.x, move.y, 0);
	}
	
	// Update is called once per frame
	void Update () {
		float timeModded = (Time.time % colorFrequency)/colorFrequency;
		if(timeModded<prevTime) {
			ChangeColor();
		}

		this.GetComponent<SpriteRenderer>().color = Color.Lerp(color1, color2, oneTwo?timeModded:1-timeModded);
		transform.Rotate(Vector3.forward * Time.deltaTime * rotationMultiplier);
		transform.position += movement;
		if(Mathf.Abs(transform.position.x)>=35) {
			movement.x *= -1;
		}
		if(Mathf.Abs(transform.position.y)>=20) {
			movement.y *= -1;
		}
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
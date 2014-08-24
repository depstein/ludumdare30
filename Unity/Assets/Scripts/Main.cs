using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
	public GameObject planetPrefab;
	public GameObject background;
	private Color sourceColor = Colors.White;
	private Color destinationColor;

	// Use this for initialization
	void Start () {
		destinationColor = Colors.GetRandomColor();
		InvokeRepeating("SpawnPlanet", 2, 1f);
		InvokeRepeating("ChangeColor", 1, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		background.GetComponent<SpriteRenderer>().color = Color.Lerp(sourceColor, destinationColor, Time.time % 1f);
	}

	void ChangeColor() {
		sourceColor = destinationColor;
		destinationColor = Colors.GetRandomColor();
	}

	void SpawnPlanet() {
		GameObject ret = Instantiate(planetPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
		ret.GetComponent<Rigidbody2D>().velocity = 5 * Random.insideUnitCircle;
    }
}

using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
	public GameObject planetPrefab;
	
	// Use this for initialization
	void Start () {
		InvokeRepeating("SpawnPlanet", 2, 1f);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void SpawnPlanet() {
		GameObject ret = Instantiate(planetPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
		ret.GetComponent<Rigidbody2D>().velocity = 5 * Random.insideUnitCircle;
    }
}

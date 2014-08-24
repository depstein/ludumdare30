using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
	public GameObject planetPrefab;
	
	public GameObject gravityObject;
	public static GameObject staticGravityObject;
	public static float GravitationalConstant = 40f;
	void Awake() {
		staticGravityObject = gravityObject;
	}

	// Use this for initialization
	void Start () {
		//InvokeRepeating("SpawnPlanet", 2, 1f);
		for (int x = 0; x < 30; x++)
		{
			SpawnPlanet();
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	void SpawnPlanet() {
		planetPrefab.GetComponent<Planet> ().Size = Random.Range (.1f, .4f);
		GameObject ret = Instantiate(planetPrefab, Random.insideUnitCircle * 10, Quaternion.identity) as GameObject;
		float angleBetweenVelocityAndRadius = Mathf.PI / 2;
		Vector3 radius = (Main.staticGravityObject.transform.position - ret.transform.position);
		float vel = Mathf.Sqrt (GravitationalConstant * staticGravityObject.rigidbody2D.mass / radius.magnitude);
		
		Vector3 dir = Vector3.Cross (radius.normalized, new Vector3 (0, 0, 1));
		ret.GetComponent<Rigidbody2D> ().velocity = vel * dir;//5 * Random.insideUnitCircle;
    }
}

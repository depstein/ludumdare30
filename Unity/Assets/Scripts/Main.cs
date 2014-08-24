using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
	public GameObject planetPrefab;
	public GameObject ProjectilePrefab;

	public GameObject gravityObject;
	public static GameObject staticGravityObject;
	public static GameObject staticProjectilePrefab;
	public static float GravitationalConstant = .025f;

	void Awake() {
		staticGravityObject = gravityObject;
		staticProjectilePrefab = ProjectilePrefab;
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

	public static void MakeProjectilesAt(GameObject planet) {
		Vector2 myPosition = planet.GetComponent<Rigidbody2D>().position;
		Vector2 myVelocity = planet.GetComponent<Rigidbody2D>().velocity;
		int numDirections = 3;
		int angleDif = 360 / numDirections;
		float dirMag = 6.0f;
		float angleRad = Mathf.Deg2Rad * angleDif;

		for (int x = 0; x < numDirections; x++)
		{
			GameObject projectile = GameObject.Instantiate(staticProjectilePrefab) as GameObject;
			Vector2 vectorDir = new Vector2(Mathf.Cos(angleRad * x), Mathf.Sin(angleRad * x)) * dirMag;
			var projectileRigidBody = projectile.GetComponent<Rigidbody2D>();
			projectileRigidBody.velocity = vectorDir;
			
			Vector2 projectilePosition = myPosition + projectileRigidBody.velocity.normalized * projectile.collider2D.bounds.size.magnitude;
			projectileRigidBody.position = projectilePosition;
		}
	}
}

using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
	public GameObject planetPrefab;
	public GameObject ProjectilePrefab;

	public GameObject gravityObject;
	public GameObject sliderObject;
	public static GameObject staticGravityObject;
	public static GameObject staticProjectilePrefab;
	public static float GravitationalConstant = .025f;
	public static float timeLeft;
	public static float maxTimeLeft;
	public static int numClicks;

	public static Main instance;

	void Awake() {
		staticGravityObject = gravityObject;
		staticProjectilePrefab = ProjectilePrefab;
		instance = this;
	}

	// Use this for initialization
	void Start () {
		BeginGame ();
	}

	void BeginGame() {
		StaticScoreboard.ResetPoints ();
		numClicks = 1;
		GameObject[] objects = GameObject.FindGameObjectsWithTag("Planet");
		foreach( GameObject go in objects )
		{
			Destroy( go );
		}

		objects = GameObject.FindGameObjectsWithTag("Projectile");
		foreach( GameObject go in objects )
		{
			Destroy( go );
		}

		maxTimeLeft = timeLeft = 8.0f;
		for (int x = 0; x < 20; x++)
		{
			SpawnPlanet();
		}
	}

	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		sliderObject.GetComponent<UISlider> ().value = timeLeft / maxTimeLeft;
		if (timeLeft <= 0)
		{
			BeginGame();
		}
	}

	void SpawnPlanet() {
		planetPrefab.GetComponent<Planet> ().Size = Random.Range (.2f, .4f);
		GameObject ret = Instantiate(planetPrefab, Vector2.Scale(Random.insideUnitCircle, new Vector2(25, 12)) + new Vector2(transform.position.x, transform.position.y), Quaternion.identity) as GameObject;
		float angleBetweenVelocityAndRadius = Mathf.PI / 2;
		Vector3 radius = (Main.staticGravityObject.transform.position - ret.transform.position);
		float vel = Mathf.Sqrt (GravitationalConstant * staticGravityObject.rigidbody2D.mass / radius.magnitude);
		
		Vector3 dir = Vector3.Cross (radius.normalized, new Vector3 (0, 0, 1));
		ret.GetComponent<Rigidbody2D> ().velocity = vel * dir;
    }

    public static void ShakeCamera(float amount)
    {
    	iTween.ShakePosition(Camera.main.gameObject, new Vector3(amount, amount, amount), .5f);
    }

	public static void MakeProjectilesAt(GameObject planet, int level) {
		Vector2 myPosition = planet.GetComponent<Rigidbody2D>().position;
		Vector2 myVelocity = planet.GetComponent<Rigidbody2D>().velocity;
		int numDirections = 3;
		int angleDif = 360 / numDirections;
		float dirMag = 20.0f;
		float angleRad = Mathf.Deg2Rad * angleDif;

		for (int x = 0; x < numDirections; x++)
		{
			float angle = angleRad * x - Mathf.Deg2Rad * 30f;
			GameObject projectile = GameObject.Instantiate(staticProjectilePrefab, new Vector2(9999, 9999), Quaternion.identity) as GameObject;
			projectile.GetComponent<Projectile>().level = level;
			Vector2 vectorDir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * dirMag;
			var projectileRigidBody = projectile.GetComponent<Rigidbody2D>();
			projectileRigidBody.velocity = vectorDir;
			
			Vector2 projectilePosition = myPosition + projectileRigidBody.velocity.normalized * projectile.collider2D.bounds.size.magnitude;
			projectileRigidBody.position = projectilePosition;
		}
	}
}

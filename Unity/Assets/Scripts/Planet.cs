using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour {

    public float InitialXVelocity;
	public bool isStartingPlanet;

	public GameObject planet;
	public GameObject explosion;

	// Use this for initialization
	void Start () {
		if (isStartingPlanet)
		{
        	GetComponent<Rigidbody2D>().velocity = new Vector2(InitialXVelocity, 0.0f);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown () {
		print ("Box Clicked!");
		Vector2 myPosition = GetComponent<Rigidbody2D> ().position;
		Vector2 myVelocity = GetComponent<Rigidbody2D> ().velocity;
		int numDirections = 5;
		int angleDif = 360 / numDirections;
		float dirMag = 3.0f / ((float)numDirections);
		float angleRad = Mathf.Deg2Rad * angleDif;
		for (int x = 0; x < numDirections; x++)
		{
			GameObject planet = (GameObject)Instantiate(Resources.Load("PlanetPrefab"));
			Vector2 vectorDir = new Vector2(Mathf.Cos(angleRad * x), Mathf.Sin (angleRad * x)) * dirMag;
			var planetRigidBody = planet.GetComponent<Rigidbody2D>();
			planetRigidBody.velocity = myVelocity + vectorDir;

			Vector2 planetPosition = myPosition + planetRigidBody.velocity.normalized * planet.collider2D.bounds.size.magnitude;
			planetRigidBody.position = planetPosition;
		}
		Destroy (this.planet);
		explosion.SetActive(true);
		Destroy(this.gameObject, 2f);
	}
}

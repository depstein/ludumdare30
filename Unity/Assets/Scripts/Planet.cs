using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour {

    public float InitialXVelocity;
	public bool isStartingPlanet;
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
		float dirMag = 3;
		int numDirections = 3;
		int angleDif = 360 / numDirections;
		float angleRad = Mathf.Deg2Rad * angleDif;
		for (int x = 0; x < numDirections; x++)
		{
			GameObject planet = (GameObject)Instantiate(Resources.Load("PlanetPrefab"));
			Vector2 vectorDir = new Vector2(Mathf.Cos(angleRad * x), Mathf.Sin (angleRad * x)) * dirMag;
			var planetRigidBody = planet.GetComponent<Rigidbody2D>();
			planetRigidBody.velocity = myVelocity + vectorDir;

			Vector2 planetPosition = myPosition + planetRigidBody.velocity.normalized * planet.collider2D.bounds.size.magnitude/2;
			planetRigidBody.position = planetPosition;
		}
		Destroy (this.gameObject);
	}
}

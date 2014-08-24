using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour
{

    public float InitialXVelocity;
    public float Size = 0.25f;
    public GameObject PlanetPrefab;
    private Vector2 lastVelocity;
    public GameObject explosion;

    void Awake()
    {
        //GetComponent<Rigidbody2D>().velocity = new Vector2(InitialXVelocity, 0.0f);
        GetComponent<Rigidbody2D>().mass = Size * 4;
        transform.localScale = new Vector3(Size, Size, 1);
        float h, s, v;
        Colors.ColorToHSV(Colors.GetRandomColor(), out h, out s, out v);
        transform.Find("Sprite").GetComponent<SpriteRenderer>().color = Colors.ColorFromHSV(h, s, .95f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        /*
        var other = collision.gameObject.GetComponent<Planet>();
        if (other != null)
        {
            var normal = collision.contacts[0].normal;
            var myVelocity = lastVelocity;
            var otherLastVelocity = other.lastVelocity;

            var myMotion = Mathf.Abs(Vector2.Dot(myVelocity, normal));
            var otherMotion = Mathf.Abs(Vector2.Dot(otherLastVelocity, normal));

            var myMomentum = myMotion * rigidbody2D.mass;
            var otherMomentum = otherMotion * other.rigidbody2D.mass;

            if (myMomentum > otherMomentum && Mathf.Abs(myMotion - otherMotion) > 1.0f)
            {
                var otherPosition = other.gameObject.rigidbody2D.position;
                var otherVelocity = other.gameObject.rigidbody2D.velocity;
                var newSize = other.Size / 2;
                GameObject.Destroy(other.gameObject);

                PlanetPrefab.GetComponent<Planet>().InitialXVelocity = 0;
                PlanetPrefab.GetComponent<Planet>().Size = newSize;
                var a = GameObject.Instantiate(PlanetPrefab) as GameObject;
                var b = GameObject.Instantiate(PlanetPrefab) as GameObject;

                a.rigidbody2D.position = otherPosition + (newSize * 2 * new Vector2(-normal.normalized.y, normal.normalized.x));
                b.rigidbody2D.position = otherPosition + (newSize * 2 * new Vector2(normal.normalized.y, -normal.normalized.x));

                a.rigidbody2D.velocity = 0.8f * otherVelocity + 0.2f * otherVelocity.magnitude * (new Vector2(-normal.normalized.y, normal.normalized.x));
                b.rigidbody2D.velocity = 0.8f * otherVelocity + 0.2f * otherVelocity.magnitude * (new Vector2(normal.normalized.y, -normal.normalized.x));

            }
        }
        */
    }

    void OnMouseDown()
    {
      /*  Vector2 myPosition = GetComponent<Rigidbody2D>().position;
        Vector2 myVelocity = GetComponent<Rigidbody2D>().velocity;
        int numDirections = 5;
        int angleDif = 360 / numDirections;
        float dirMag = 3.0f / ((float)numDirections);
        float angleRad = Mathf.Deg2Rad * angleDif;
        for (int x = 0; x < numDirections; x++)
        {
            PlanetPrefab.GetComponent<Planet>().Size = 0.25f;
            GameObject planet = Instantiate(PlanetPrefab) as GameObject;
            Vector2 vectorDir = new Vector2(Mathf.Cos(angleRad * x), Mathf.Sin(angleRad * x)) * dirMag;
            var planetRigidBody = planet.GetComponent<Rigidbody2D>();
            planetRigidBody.velocity = myVelocity + vectorDir;

            Vector2 planetPosition = myPosition + planetRigidBody.velocity.normalized * planet.collider2D.bounds.size.magnitude;
            planetRigidBody.position = planetPosition;
        }*/

		this.gameObject.collider2D.enabled = false;
		Main.MakeProjectilesAt (this.gameObject);
        GetComponent<Animator>().Play("Explode");
        Destroy(this.gameObject, 2f);
    }

    void FixedUpdate()
    {
        lastVelocity = GetComponent<Rigidbody2D>().velocity;
		Vector3 radius = (Main.staticGravityObject.transform.position - transform.position);
		if (radius.magnitude < 1)
		{
			radius = radius.normalized;
		}
		Vector3 numerator = radius.normalized * Main.staticGravityObject.rigidbody2D.mass;
		float denominator = radius.sqrMagnitude;
		Vector3 force = numerator * Main.GravitationalConstant / denominator;
		rigidbody2D.AddForce(force);
    }
}

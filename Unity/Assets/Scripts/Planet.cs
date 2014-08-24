using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour {

    public float InitialXVelocity;
    public float Size;
    public GameObject PlanetPrefab;
    private Vector2 lastVelocity;

	void Awake () 
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(InitialXVelocity, 0.0f);
        GetComponent<Rigidbody2D>().mass = Size * 4;
        transform.localScale = new Vector3(Size, Size, 1);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
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
    }

    void FixedUpdate()
    {
        lastVelocity = GetComponent<Rigidbody2D>().velocity;
    }
}

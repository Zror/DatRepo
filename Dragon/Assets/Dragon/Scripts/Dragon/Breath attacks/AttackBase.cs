using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]
public class AttackBase : MonoBehaviour
{
    public Rigidbody2D body;
    public int angle;
    public bool spec1;
    public bool spec2;
    public Flight Dragon;
    public float speedAddition;
    public float rate;
    float speed = 0.0f;
    public AudioSource Audi;
    float last;
    // Use this for initialization
    void Start()
    {
        if( GetComponent<AudioSource>() != null)
        {
            Audi = GetComponent<AudioSource>();
        }
        Dragon = FindObjectOfType<Flight>();
        speed = Dragon.getForwardSpeed() + speedAddition;
        body = GetComponent<Rigidbody2D>();
        float angle = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        body.velocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * speed;
        last = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(body.velocity.y, body.velocity.x) * Mathf.Rad2Deg);
        last -= Time.deltaTime;
        if (last <= 0)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag.Equals(Globals.TAGS.Enemy)) { Destroy(coll.gameObject); }
        if (coll.tag.Equals(Globals.TAGS.Enemy)|| coll.tag.Equals(Globals.TAGS.World)) { Destroy(this.gameObject); }
        if( Audi != null)
        {
            Audi.Play();
        }

    }
}

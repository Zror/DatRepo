using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]
public class base_projectile : MonoBehaviour {
    public float speed = 0.0f;
    public Rigidbody2D body;
    public float angle;
    private float last;
    // Use this for initialization
    void Start () {
        body = GetComponent<Rigidbody2D>();
        //angle = transform.rotation.eulerAngles.z*Mathf.Deg2Rad;
        //body.velocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle))*speed;
        last = 2.5f;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(body.velocity.y, body.velocity.x)*Mathf.Rad2Deg);
        last -= Time.deltaTime;
        if (last <= 0)
        {
            Destroy(gameObject);
        }
	}
}

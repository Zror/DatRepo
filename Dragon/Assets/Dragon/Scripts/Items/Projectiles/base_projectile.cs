using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]
public class base_projectile : MonoBehaviour {
    public float speed = 0.0f;
    Rigidbody2D body;
    public float angle;
    // Use this for initialization
    void Start () {
        body = GetComponent<Rigidbody2D>();
        angle = transform.rotation.eulerAngles.z*Mathf.Deg2Rad;
        body.velocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle))*speed;
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(body.velocity.y, body.velocity.x)*Mathf.Rad2Deg);
	}
}

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class VelocityLimit : MonoBehaviour {

    public float maxVelocity = 5;
    public float velocityTimeScale = 0.00025f;
    public float velocityCap = 10;

    private Rigidbody2D body;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        maxVelocity += Time.fixedDeltaTime * velocityTimeScale;

	    if (maxVelocity > velocityCap)
	    {
            maxVelocity = velocityCap;
	    }

	    if (body.velocity.magnitude > maxVelocity)
	    {
            body.velocity = body.velocity.normalized * maxVelocity;
	    }
	}
}

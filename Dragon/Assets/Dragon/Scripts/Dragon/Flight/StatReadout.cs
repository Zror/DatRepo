using UnityEngine;
using System.Collections;

public class StatReadout : MonoBehaviour {
	public Vector2 velocity;

	private Rigidbody2D body;
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		velocity = body.velocity;
	}

}

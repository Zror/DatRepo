using UnityEngine;
using System.Collections;

public class Wings : MonoBehaviour {

    public float velocity;

    private Rigidbody2D rigidbody;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(new Vector2(0, velocity));
        }
	}

    void FixedUpdate()
    {

    }
}

using UnityEngine;
using System.Collections;

public class Wings : MonoBehaviour {

    public float velocity;

    private Rigidbody2D rigidbody;

    private bool overFire;

    private float grav;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
	}

    //Use this for gliding over fires
    void Updraft() {
      /*
      At the moment this is just bound to a key, 
      this will be changed when we have a fire object and a way to check for collision 
      between the dragon and the air above a fire.
      */ 
    rigidbody.AddForce(new Vector2(0, 1.25F * velocity));
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(new Vector2(0, velocity));
        }
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            Updraft();
        }
    }

    void FixedUpdate()
    {

    }
}

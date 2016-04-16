using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public abstract class Flight : MonoBehaviour {

	public float velocity = 300;

    protected new Rigidbody2D rigidbody;

    private bool overFire;

    private float grav;

    protected new HealthMonitor health;

    private float maxSpeed = 25;

    public AudioSource Audi;

    
	// Use this for initialization
	public virtual void Start () {
        rigidbody = GetComponentInParent<Rigidbody2D>();
        health = GetComponentInParent<HealthMonitor>();
        Audi = GetComponentInParent<AudioSource>();
    }

    //Use this for gliding over fires
    //void Updraft() {
      /*
      At the moment this is just bound to a key, 
      this will be changed when we have a fire object and a way to check for collision 
      between the dragon and the air above a fire.
      */ 
    //rigidbody.AddForce(new Vector2(0, 1.25F * velocity));
    //}
	
	// Update is called once per frame
	public virtual void Update ()
	{
	    Input.simulateMouseWithTouches = true;

        if (Input.GetMouseButtonDown(0) && health.HasStamina && clickLeft())
        {
           rigidbody.AddForce(new Vector2(velocity * .55F, velocity));
            health.ChangeStamina(-1);
            Audi.Play();
        }
        if (Input.GetKeyDown(KeyCode.LeftAlt))
       {
            //Updraft();
        }
    }

    void FixedUpdate()
    {
		if(rigidbody.velocity.x > maxSpeed){
			rigidbody.velocity = new Vector2(maxSpeed, rigidbody.velocity.y);
		}
    }
    
    public float getForwardSpeed()
    {
        return rigidbody.velocity.x;
    }

    public bool clickLeft()
    {
        //Returns if the mouse is clicked on the left quarter of the screen
        Input.simulateMouseWithTouches = true;
        if (Input.mousePosition.x < (Screen.width / 4))
        {
            return true;
        }
        return false;

    }
}

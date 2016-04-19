using UnityEngine;
using System.Collections;

public class HangGlider : Flight {


    public override void Start()
    {
        base.Start();
        rigidbody.AddForce(new Vector2(velocity,velocity*5));
        
        
    }
	// Update is called once per frame
	public override void Update () {
        Input.simulateMouseWithTouches = true;
        if (Input.GetMouseButtonDown(0) && health.HasStamina && clickLeft()) { 
            if ( rigidbody.velocity.x > 10){
				rigidbody.AddForce(new Vector2(velocity * .55F, velocity));
                health.ChangeStamina(-1);
            }
			else
				rigidbody.AddForce(new Vector2(velocity, 0));
		}
	}

       

}

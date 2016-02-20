using UnityEngine;
using System.Collections;

public class HangGlider : Flight {

	// Update is called once per frame
	public override void Update () {
        Input.simulateMouseWithTouches = true;

        if (Input.GetMouseButtonDown(0) && health.HasStamina && clickLeft())
        {
            if ( rigidbody.velocity.x > 15){
				rigidbody.AddForce(new Vector2(velocity * .55F, velocity));
                health.ChangeStamina(-1);
            }
			else
				rigidbody.AddForce(new Vector2(velocity * .55F, 0));
		}
	}
}

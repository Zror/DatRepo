using UnityEngine;
using System.Collections;

public class HangGlider : Flight {

	// Update is called once per frame
	public override void Update () {
		if (Input.GetKeyDown(KeyCode.Space)){
			if( rigidbody.velocity.x > 15){
				rigidbody.AddForce(new Vector2(velocity * .55F, velocity));
			}
			else
				rigidbody.AddForce(new Vector2(velocity * .55F, 0));
		}
	}
}

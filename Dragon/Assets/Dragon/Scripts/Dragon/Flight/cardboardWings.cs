using UnityEngine;
using System.Collections;

public class cardboardWings : Flight{
     
	private float scalar = .5F;

	public override void Start(){
		velocity = (velocity * scalar);

		base.Start ();
	}
}

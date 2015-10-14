using UnityEngine;
using System.Collections;

public class cardboardWings : Flight{

	public float scalar = .25F;

	public override void Start(){
		velocity = (velocity * scalar);

		base.Start ();
	}

	// Use this for initialization

}

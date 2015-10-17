using UnityEngine;
using System.Collections;

public class Tower_script : MonoBehaviour {
	public float Spawn_Chance = 0.85f;
	private GameObject Princess;

	// Brett Kriz
	void Start () {
		// Roll the dice  
		// (If chance is 1, theres nothing less than 1 that can be rolled)
		// #Statistics lol
		if (Random.value < Spawn_Chance) {
			// spawn in a princess on TOP of the tower
			Bounds area = this.GetComponent<BoxCollider2D> ().bounds;
			Vector3 t = new Vector3 (area.center.x, area.center.y + 500, 0); // 0 B/C layers
			Vector3 top_center = area.ClosestPoint (t);
			// Setup and spawn the princess
			this.Princess = (GameObject)Instantiate (Resources.Load ("Princess"), top_center, Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate (){

	}


}

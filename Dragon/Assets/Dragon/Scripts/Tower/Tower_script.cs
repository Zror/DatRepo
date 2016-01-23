using UnityEngine;
using System.Collections;

public class Tower_script : MonoBehaviour {
	public float Spawn_Chance = 0.85f;
    public Transform princess_spawn_location;
	private GameObject Princess;

	// Brett Kriz
	void Start () {
		// Roll the dice  
		// (If chance is 1, theres nothing less than 1 that can be rolled)
		// #Statistics lol
		if (Random.value < Spawn_Chance) {
			// spawn in a princess on TOP of the towerSpawnCounter

			// Setup and spawn the princess
			this.Princess = (GameObject)Instantiate (Resources.Load ("Princess"), princess_spawn_location.position, Quaternion.identity);
            // Needed for the shifting scene
            this.Princess.transform.parent = this.transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate (){

	}


}

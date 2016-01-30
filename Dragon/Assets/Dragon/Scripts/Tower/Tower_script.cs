using UnityEngine;
using System.Collections;

public class Tower_script : MonoBehaviour {
    public float Spawn_Chance = 0.25f; //0.85f;
    public Vector3 princess_spawn_location;
	private GameObject Princess;

	// Brett Kriz
	void Start () {
		// Roll the dice  
		// (If chance is 1, theres nothing less than 1 that can be rolled)
		// #Statistics lol
		if (Random.value < Spawn_Chance) {
            // spawn in a princess on TOP of the towerSpawnCounter
            this.princess_spawn_location = this.transform.position + new Vector3(0, 8, 0);
            // Setup and spawn the princess
            this.Princess = (GameObject)Instantiate(Resources.Load("Princess"), princess_spawn_location, Quaternion.identity);
            // Needed for the shifting scene
            this.Princess.transform.parent = this.transform;
		}

        float dist = (this.transform.position.y);
        Debug.Log("DISTANCE FROM CENTER TO TOP: "+dist);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate (){

	}


}

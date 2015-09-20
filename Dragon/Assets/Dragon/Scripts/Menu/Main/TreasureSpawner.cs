using UnityEngine;
using System.Collections;

public class TreasureSpawner : MonoBehaviour {

    public int treasureAmount;
    public WeightedTreasure[] treasurePile = new WeightedTreasure[] {
        new WeightedTreasure() { weight = 10, treasure = null }
    };
    public float spawnRate;
    public float positionJitter;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
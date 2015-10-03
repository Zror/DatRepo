using UnityEngine;
using System.Collections;

public class TreasureSpawner : MonoBehaviour {

    public int treasureAmount;
    public WeightedTreasure[] treasurePile = new WeightedTreasure[] {
        new WeightedTreasure() { weight = 10, treasure = null }
    };
    public GameObject[] treasureThings = new GameObject[0];
    public float spawnRate;
    public float positionJitter;

    private int spawned = 0;
    private float countDownTimer;

	// Use this for initialization
	void Start ()
	{
	    countDownTimer = spawnRate;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    countDownTimer -= Time.deltaTime;

        while(countDownTimer < 0 && spawned < treasureAmount)
        {
            Vector2 offset = Random.insideUnitCircle * positionJitter;

            GameObject selected = treasureThings[Random.Range(0, treasureThings.Length)];
            Vector3 position = this.transform.position;
            position.x += offset.x;
            position.y += offset.y;
            Instantiate(selected, position, this.transform.rotation);

            spawned += 1;
            countDownTimer += spawnRate;
        }

        if (spawned >= treasureAmount)
        {
            Destroy(this);
        }
	}
}
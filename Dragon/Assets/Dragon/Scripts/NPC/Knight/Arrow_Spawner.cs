using UnityEngine;
using System.Collections;

public class Arrow_Spawner : MonoBehaviour {
    public float rate = 2.5f;
    private float timer;
    public GameObject projectile;
	// Use this for initialization
	void Start () {
        timer = rate;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, 135));
            timer += rate;
        }
	}
}

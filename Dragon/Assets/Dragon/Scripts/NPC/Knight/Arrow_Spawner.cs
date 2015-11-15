using UnityEngine;
using System.Collections;

public class Arrow_Spawner : MonoBehaviour {
    public float rate = 2.5f;
    private float timer;
    public GameObject projectile;
    public AutoAim aimer;
	// Use this for initialization
	void Start () {
        timer = rate;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
           // float time = projectile.GetComponent<base_projectile>().speed / projectile.GetComponent<Rigidbody2D>().gravityScale;
           // projectile.GetComponent<base_projectile>().angle = aimer.arcTan(time, transform.position.x,transform.position.y);
            Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, 135));
            timer += rate;
        }
	}
}

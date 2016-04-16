using UnityEngine;
using System.Collections;

public class Arrow_Spawner : MonoBehaviour {
    public float rate = 2.5f;
    private float timer;
    public GameObject projectile;
    public AutoAim aimer;
    public AudioSource Audi;
	// Use this for initialization
	void Start () {
        timer = rate;
        Audi = GetComponent<AudioSource>();
        gameObject.transform.parent = FindObjectOfType<FloatingOrigin>().transform;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer < 0)
        {

            GameObject arrow=(GameObject) Instantiate(projectile,transform.position, Quaternion.Euler(0, 0, 135));
            
            arrow.GetComponent<base_projectile>().angle = aimer.angle(transform.position.x, transform.position.y, projectile.GetComponent<base_projectile>().speed) * Mathf.Deg2Rad;
            arrow.GetComponent<base_projectile>().body.velocity = new Vector2(Mathf.Cos(arrow.GetComponent<base_projectile>().angle), Mathf.Sin(arrow.GetComponent<base_projectile>().angle)) * arrow.GetComponent<base_projectile>().speed;

            arrow.transform.parent = this.transform.parent;
            Audi.Play();
            timer += rate;
        }
	}

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        float angle = aimer.angle(transform.position.x, transform.position.y, projectile.GetComponent<base_projectile>().speed) * Mathf.Deg2Rad;
        Gizmos.DrawRay(this.transform.position, new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0));
    }
}

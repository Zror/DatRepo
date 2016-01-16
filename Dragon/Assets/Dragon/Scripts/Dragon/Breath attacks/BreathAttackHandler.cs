using UnityEngine;
using System.Collections;

public class BreathAttackHandler : MonoBehaviour {
    public GameObject[] objects;
    public int selected;
    public HealthMonitor monitor;
    bool forceHeld;
    AttackBase breath;
    float timer;
    // Use this for initialization
    void Start () {
        forceHeld = false;
        breath = objects[selected].GetComponent<AttackBase>();
        timer = breath.rate;
    }
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetMouseButton(1)||forceHeld)&&monitor.Flame!=0)
        {
            timer -= Time.deltaTime;
            monitor.ChangeFlame(0-Time.deltaTime);
            if (timer <= 0)
            {
                if (breath.spec1 || breath.spec2)
                {
                    forceHeld = true;
                }
                if (breath.spec1)
                {
                    bulletHell();
                }
                else if (breath.spec2)
                {
                    shoopdawhoop();
                }
                else
                {
                    normal();
                }
                timer += breath.rate;
            }
            if (monitor.Flame == 0)
            {
                forceHeld = false;
            }
        }
	}
    void normal()
    {
        GameObject attack= (GameObject)Instantiate(objects[selected], transform.position, Quaternion.Euler(0, 0, breath.angle));
        attack.transform.parent = this.transform.parent;
    }
    void bulletHell()
    {
        Random.seed = System.DateTime.Now.Millisecond;
        int angle = Random.Range(0, 360);
        GameObject attack = (GameObject)Instantiate(objects[selected], transform.position, Quaternion.Euler(0, 0,angle));
        attack.transform.parent = this.transform.parent;
    }
    void shoopdawhoop()
    {
        Random.seed = System.DateTime.Now.Millisecond;
        int angle = Random.Range(0, 360);
        GameObject attack = (GameObject)Instantiate(objects[selected], transform.position, Quaternion.Euler(0, 0, 315));
        attack.transform.parent = this.transform.parent;
    }
}

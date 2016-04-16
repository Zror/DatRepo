using UnityEngine;
using System.Collections;

public class BreathAttackHandler : MonoBehaviour {
    public GameObject[] objects;
    private SavedData stats;
    private int selected;
    public HealthMonitor monitor;
    bool forceHeld;
    AttackBase breath;
    private float angle;
    private Session_Monitor session;
    float timer;
    private float xScale;
    private Vector3 spawn;
    Perks p;
    // Use this for initialization
    void Start () {
        forceHeld = false;
        /*Data temp = GameObject.FindGameObjectWithTag("Load").GetComponent<Data>();
        if (temp != null)
        {
            selected = temp.get().breathSelected;
            Debug.Log(selected);
        }*/
        session = FindObjectOfType<Session_Monitor>();
        selected = session.getBreaths();
        Debug.Log(selected);
        breath = objects[selected].GetComponent<AttackBase>();
        timer = breath.rate;
        xScale = transform.lossyScale.x / 2;
        p = gameObject.GetComponentInParent<Perks>();
    }
	
	// Update is called once per frame
	void Update () {
        Input.simulateMouseWithTouches = true;
        if ((Input.GetMouseButton(0)||forceHeld)&&monitor.Flame!=0)
        {
            Vector3 position=Input.mousePosition;
            if (position.x > (Screen.width / 4)||forceHeld)
            {
                position = Camera.main.ScreenToWorldPoint(position);
                float xx = position.x - (gameObject.transform).position.x;
                float yy = Mathf.Abs(position.y) - Mathf.Abs((gameObject.transform).position.y);
                angle = (Mathf.Atan2(Mathf.Abs(yy), Mathf.Abs(xx)) * Mathf.Rad2Deg);
                Debug.Log(angle + "\n");
                if (position.y < gameObject.transform.position.y)
                {
                    angle *= -1;
                }
                timer -= Time.deltaTime;
                monitor.ChangeFlame((0 - Time.deltaTime)*p.breathMult());
                Debug.Log(monitor.Flame);
                if (timer <= 0)
                {
                    spawn = new Vector3(transform.position.x + Mathf.Cos(angle * Mathf.Deg2Rad) * xScale, transform.position.y);
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
	}
    void normal()
    { 
        GameObject attack= (GameObject)Instantiate(objects[selected], spawn, Quaternion.Euler(0, 0, angle));
        attack.transform.parent = this.transform.parent;
    }
    void bulletHell()
    {
        Random.seed = System.DateTime.Now.Millisecond;
        int angle = Random.Range(0, 360);
        GameObject attack = (GameObject)Instantiate(objects[selected], spawn, Quaternion.Euler(0, 0,angle));
        attack.transform.parent = this.transform.parent;
    }
    void shoopdawhoop()
    {
        int angle = Random.Range(0, 360);
        GameObject attack = (GameObject)Instantiate(objects[selected], spawn, Quaternion.Euler(0, 0, 330));
        attack.transform.parent = this.transform.parent;
    }
}

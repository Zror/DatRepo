using UnityEngine;
using System.Collections;

public class BreathAttackHandler : MonoBehaviour {
    public GameObject[] objects;
    public int selected;
    public HealthMonitor monitor;
    bool forceHeld;
    AttackBase breath;
    // Use this for initialization
    void Start () {
        forceHeld = false;
        breath = objects[selected].GetComponent<AttackBase>();
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetMouseButtonDown(0)||forceHeld)
        {
            if (breath.spec1 || breath.spec2)
            {
                forceHeld = true;
            }
        }
	}
}

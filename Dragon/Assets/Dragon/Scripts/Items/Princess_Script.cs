using UnityEngine;
using System.Collections;

public class Princess_Script : MonoBehaviour {

    public Session_Monitor monitor;

    // Use this for initialization
    void Start () {
        this.monitor = FindObjectOfType<Session_Monitor>();
    }
	    
    void FixedUpdate()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Reward a princess and remove
        monitor.Princesses_Taken();

        Destroy(this.gameObject);
    }

}

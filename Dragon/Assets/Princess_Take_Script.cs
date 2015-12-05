using UnityEngine;
using System.Collections;

public class Princess_Take_Script : MonoBehaviour {
    public static Session_Monitor mon;
	// Use this for initialization
	void Start () {
        if (mon == null)
        {
            mon = Session_Monitor.Instance;
        }  
	}
	
	// Update is called once per frame
	void Update () {
	    
    
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == Globals.TAGS.Player)
        {
            // Good, count and delete
            mon.Princesses_Taken();

            Destroy(this.gameObject);
        }
    }

}

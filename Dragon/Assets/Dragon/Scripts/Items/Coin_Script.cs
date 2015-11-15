using UnityEngine;
using System.Collections;

public class Coin_Script : MonoBehaviour {

    public uint Worth = 1;
    public Session_Monitor monitor;
    // Use this for initialization
    void Start () {
        this.monitor = FindObjectOfType<Session_Monitor>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        // GIVE MONEY AND LEAVE!
        monitor.Add_Coins(this.Worth);

        Destroy(this.gameObject);
    }


}

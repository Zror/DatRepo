using UnityEngine;
using System.Collections;

public class base_item : MonoBehaviour {

	public int award_HP = 0;
	public int award_Stam = 0;
	public float award_Flame = 0f;
	public uint award_Coin_Value = 0;
    public Session_Monitor monitor;

    // Use this for initialization
    void Start () {
		// Correct init logics
		this.tag 				= Globals.TAGS.Item;
		this.award_Flame 		= Mathf.Max (award_Flame, 0f);
        this.monitor = FindObjectOfType<Session_Monitor>();

    }
	
	// Update is called once per frame
	// IE nothing heavy here!!!
	void Update () {
	
	}

	// FixedUpdate is called every Physics tick
	void FixedUpdate(){


	}

	// On trigger collision
	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == Globals.TAGS.Player) // @@@ENUM HERE!!!
		{
			GameObject dragon = coll.gameObject;
			UseItem(dragon); // For non awarding actions

			HealthMonitor dragonSM = dragon.GetComponent<HealthMonitor>();
			dragonSM.StatInput( this.award_HP,
			                   	this.award_Stam,
			                   	this.award_Flame);
            // @@@ SESSION MONITOR
            monitor.Add_Coins(this.award_Coin_Value);


        }

		Destroy(this.gameObject); // Goodbye
	}

	// What we need to do to use this item
	// (BESIDES AWARDING STATS)
	void UseItem(GameObject on_who)
	{
		// YOUR code here
		
	}
}

﻿using UnityEngine;
using System.Collections;

public class base_item : MonoBehaviour {

	public int award_HP = 0;
	public int award_Stam = 0;
	public float award_Flame = 0f;

	// Use this for initialization
	void Start () {
		this.tag = Globals.TAGS.Item;
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

		}

		Destroy(this); // Goodbye
	}

	// What we need to do to use this item
	// (BESIDES AWARDING STATS)
	void UseItem(GameObject on_who)
	{
		// YOUR code here
		
	}
}
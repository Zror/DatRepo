using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Session_Monitor : MonoBehaviour {

    private static Session_Monitor _instance = null;
    public static Session_Monitor Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Session_Monitor>();
            }
            return _instance;
        }
    }

	// Track the current sessions information
	private Dictionary<string,uint> data = new Dictionary<string,uint>();

	public readonly bool HL3_confirmed = true;

	/*
	 * Livestock
	 * Princesses
	 * Haybails burned
	 * Clouds hit
	 * 
	*/

	public int earned_coins = 0; // Merge me!
	public int Livestock_destroyed = 0;
	public int Prioncesses_taken = 0;
	public int Hay_burned = 0;
	public int Clouds_hit = 0;

	private float time_elapsed = -1f;
	private uint calls = 0;

	// This is for Dan's request
	private bool[] perks;
	private bool[] wings;
	private bool[] breaths;
	private bool[] skins;

	public int perks_i = 0;
	public int wings_i = 0;
	public int breaths_i = 0;
	public int skins_i = 0;

	public static readonly string CALLS 				= "calls";
	public static readonly string EARNED_COINS 			= "earned_coins";
	public static readonly string LIVESTOCK_DESTROYED 	= "Livestock_destroyed";
	public static readonly string PRINCESSES_TAKEN 		= "Princesses_taken";
	public static readonly string HAY_BURNED 			= "Hay_burned";
	public static readonly string CLOUDS_HIT 			= "Clouds_hit";
	
	// Use this for initialization
	void Start () {
		// Enforce definitions o.O

		this.data.Add(CALLS					, 0);
		this.data.Add(EARNED_COINS			, 0);
		this.data.Add(LIVESTOCK_DESTROYED	, 0);
		this.data.Add(PRINCESSES_TAKEN		, 0);
		this.data.Add(HAY_BURNED			, 0);
		this.data.Add(CLOUDS_HIT			, 0);


		this.time_elapsed = -1f; // Stays out of the table until the end lol

	}
	
	// COUNTS
	void FixedUpdate() {
		this.time_elapsed += Time.fixedDeltaTime;
	}

	public void Add_Coins(uint amt){
		this.data [EARNED_COINS] += amt;
		this.calls++;
	}

	public void Livestock_Destroyed(){
		this.data [LIVESTOCK_DESTROYED]++;
		this.calls++;
	}

	public void Princesses_Taken(){
		this.data [PRINCESSES_TAKEN]++;
		this.calls++;
	}

	public void Hay_Burned(){

		this.data [HAY_BURNED]++;
		this.calls++;
	}

	public void Clouds_Hit(){
		this.data [CLOUDS_HIT]++;
		this.calls++;
	}


	// ACCESSORS
	public int getWings(){
		if (wings[wings_i]){
			return this.wings_i;
		}else{
			return 0;
		}
	}
	
	public int getPerks(){
		if (perks[perks_i]){
			return this.perks_i;
		}else{
			return 0;
		}
	}
	
	public int getBreaths(){
		if (breaths[breaths_i]){
			return this.breaths_i;
		}else{
			return 0;
		}
	}

	public int getSkins(){
		if (skins[skins_i]){
			return this.skins_i;
		}else{
			return 0;
		}
	}

	public float getElapsed(){
		return this.time_elapsed;
	}

	Dictionary<string,uint> Export_Data (bool halt_monitor){
		// Load an object file to send out.
		// 

		/*
		if (halt_monitor == true) {
			// END THIS MONITOR!
			this.End();
		}
		*/

		return this.data;
	}

	 private void End(){
		// End the session_monitor

		//Destory( this.gameObject );

		// EXPORT STATS TO MAIN!
	}
}

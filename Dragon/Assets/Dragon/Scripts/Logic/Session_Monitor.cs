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

	public uint earned_coins = 0; // Merge me!
	public int Livestock_destroyed = 0;
	public int Princesses_taken = 0;
	public int Hay_burned = 0;
	public int Clouds_hit = 0;

	private float time_elapsed = -1f;
	private uint calls = 0;

	// This is for Dan's request
	private List<bool> perks;
	private List<bool> wings;
	private List<bool> breaths;
	private List<bool> skins;

	public int perks_i;
	public int wings_i;
	public int breaths_i;
	public int skins_i;

	public static readonly string CALLS 				= "calls";
	public static readonly string EARNED_COINS 			= "earned_coins";
	public static readonly string LIVESTOCK_DESTROYED 	= "Livestock_destroyed";
	public static readonly string PRINCESSES_TAKEN 		= "Princesses_taken";
	public static readonly string HAY_BURNED 			= "Hay_burned";
	public static readonly string CLOUDS_HIT 			= "Clouds_hit";

    SavedData saveStuff;
	void Awake()
    {
        Data temp = GameObject.FindGameObjectWithTag("Load").GetComponent<Data>();
        if (temp != null)
        {
            saveStuff = temp.get();

            perks = saveStuff.perks;
            breaths = saveStuff.breath;
            wings = saveStuff.wings;
            skins = saveStuff.skins;

            perks_i = saveStuff.perkSelected;
            breaths_i = saveStuff.breathSelected;
            wings_i = saveStuff.wingSelected;
            skins_i = saveStuff.skinSelected;

            Debug.Log(perks_i + ", " + breaths_i + ", " + wings_i + ", " + skins_i);
        }
    }
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
			return this.wings_i;
	}
	
	public int getPerks(){
			return this.perks_i;
	}
	
	public int getBreaths(){
        Debug.Log(perks_i + ", " + breaths_i + ", " + wings_i + ", " + skins_i);
        return breaths_i;
	}

	public int getSkins(){
			return this.skins_i;
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
        earned_coins += (uint)Princesses_taken * 75;
        FindObjectOfType<Data>().updateThings(earned_coins, Princesses_taken);
        // End the session_monitor

		//Destory( this.gameObject );

		// EXPORT STATS TO MAIN!
	}
}

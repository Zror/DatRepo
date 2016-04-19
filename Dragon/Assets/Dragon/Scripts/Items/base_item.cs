using UnityEngine;
using System.Collections;
using System.Linq;

public class base_item : MonoBehaviour {

	public int award_HP = 0;
	public int award_Stam = 0;
	public float award_Flame = 0f;
	public uint award_Coin_Value = 0;
    public bool Is_LiveStock = false;

    //This is bad code, never do this again
    public CoinSpin coin;
    AudioSource Audi;


    public static Session_Monitor monitor;
    public static HealthMonitor dragonSM;

    Perks p;

    // Use this for initialization
    void Start () {
        // Correct init logics

        if (GetComponent<CoinSpin>() != null)
        {
            coin = GetComponent<CoinSpin>();
        }

        if (GetComponent<AudioSource>() != null)
        {
            //Audi = GetComponent<AudioSource>();
        }
        this.tag = Globals.TAGS.Item;
        this.award_Flame = Mathf.Max(award_Flame, 0f);
        if (monitor == null)
        {
            monitor = Session_Monitor.Instance;
            Audi = ((AudioSource )monitor.gameObject.GetComponent<AudioSource>());
        }
        if (dragonSM == null)
        {
            dragonSM = FindObjectsOfType<HealthMonitor>().First(t => t.tag == Globals.TAGS.Player);
        }
        Audi = ((AudioSource)monitor.gameObject.GetComponent<AudioSource>());
        if(GetComponent<CoinSpin>() == null)
        {
            Audi = null;
        }
        p = FindObjectOfType<Perks>();
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
        if(coll.gameObject.tag== Globals.TAGS.Enemy)
        {
            return;
        }
       
        if (coll.gameObject.tag == Globals.TAGS.Player) // @@@ENUM HERE!!!
		{
			GameObject dragon = coll.gameObject;
			UseItem(dragon); // For non awarding actions

            if (Audi != null)
            {
                Audi.Play();
            }
            int hp = this.award_HP;
            int stam = this.award_Stam;
            float flame = this.award_Flame;

            if (p == null)
            {
                p = gameObject.GetComponent<Perks>();
            }

            if (p.BE())
            {
                stam *= 2;
                flame *= 2;
            }
            if (hp < 0)
            {
                Debug.Log("1");
                dragonSM.HP += (int)(hp * p.damageMult()) + p.damageReduction();
            }
            if(hp>0 && p.BE())
            {
                dragonSM.HP += hp * 2;
            }
            monitor.Add_Coins(award_Coin_Value);
            Debug.Log(award_Coin_Value);
            dragonSM.StatInput(hp, stam,flame);
            // @@@ SESSION MONITOR
            //monitor.Add_Coins(this.award_Coin_Value);
		Destroy(this.gameObject); // Goodbye
	}
	}

	// What we need to do to use this item
	// (BESIDES AWARDING STATS)
	void UseItem(GameObject on_who)
	{
		// YOUR code here
		
	}
}

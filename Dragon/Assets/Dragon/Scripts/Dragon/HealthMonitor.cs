using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthMonitor : MonoBehaviour {

    public int HP = 100;
    public int MaxHP = 100;

    public int Stamina = 100;
    public int MaxStamina = 100;

    public float Flame = 5f; // Fuel; Represents burntime in seconds?
    public float MaxFlame = 8f;

    public bool DEBUG_Bleedout_on = false;
    public bool Allow_Stamina_Regen = false;
    //public Text t;
    //public 

    public Collider2D Collison;
    public Rigidbody2D RBody;
    public Session_Monitor Ses;

    public bool onGround = true;
    

    private static HealthMonitor _instance = null;

    public static HealthMonitor Instance // Use to call the opnly instance of the HealthMonitor
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<HealthMonitor>();
            }
            return _instance;
        }
    }

	// Use this for initialization
    void Awake()
    {
        // If the starting HP is not set, set as total
        // So people dont die RIGHT at start
        this.HP = this.MaxHP;

        if (Collison == null)
        {
            Collison = GetComponent<Collider2D>();
        }
        if (RBody == null)
        {
            RBody = GetComponent<Rigidbody2D>();
        }
        if (Ses == null)
        {
            Ses = Session_Monitor.Instance;
        }
    }

    void Start () {

        
        
	}
	
	// Update is called once per frame
	void Update () {
        //t.text = "Hp: " + HP + "\nStamina: " + Stamina + "\nFuel:" + Flame;
        if (HP <= 0)
        {
            Session_Monitor s = FindObjectOfType<Session_Monitor>();
            s.End();
        }
	}

    void FixedUpdate()
    {
        // In addition to physics...
        // Fixed interval regen will be handled here

        if (this.Allow_Stamina_Regen && this.Stamina < MaxStamina)
        {
            // Allow Stamina regen (when not in use)
           // this.Stamina += 2;
        }
        if (DEBUG_Bleedout_on == true)
        {
            this.HP -= 1;
            //Debug.Log("[i] Bleeding... -1 -> "+this.HP);
    }
    }

	public void StatInput(uint HP_add, uint Stam_add, float Flame_add)
	{
		this.StatInput ((int)HP_add, (int)Stam_add, Flame_add);
	}

    public void StatInput(int HP_add, int Stam_add, float Flame_add)
    {
        /* StatInput
         * This function simply adds the numbers
         * to their respective meters.
         * 
         * Input 0's for no change.
         * 
         * 
         */
        Debug.Log("[i] HP:" + HP_add + " STAM:" + Stam_add + " FLAME:" + Flame_add);
        this.ChangeHP(HP_add);
        this.ChangeStamina(Stam_add);
        this.ChangeFlame(Flame_add);
    }

    public float GetStatAtIndex(int i)
    {
        // A handy method for grabbing any stat with only an int
        /*
            How to use:
            0 = HP
            1 = Stamina
            2 = Flame
            3 (not supposed to be passed, returns 1 for use with SIN)
            else IDK
        */
        switch (i)
        {
            case 0: return (float)this.HP;
            case 1: return (float)this.Stamina;
            case 2: return this.Flame;
            case 3: return 1;
            default: Debug.LogError("[!] GetStatAtIndex was given a VERY bad index! @" + i); break;
        }
        return -1f;
    }

    public int GetLimitAtIndex(int i)
    {
        // A handy method for grabbing any stat Limit with only an int
        /*
            How to use:
            0 = HP
            1 = Stamina
            2 = Flame
            else IDK
        */

        switch (i)
        {
            case 0: return this.MaxHP;
            case 1: return this.MaxStamina;
            case 2: return (int)this.MaxFlame;
            default: Debug.LogError("[!] GetLimitAtIndex was given a VERY bad index! @" + i); break;
    }
        return 0;
    }

    public bool IsAlive
    { // Attribute
        get { return this.HP > 0; }
    }
    public bool IsDead
    {
        get { return !this.IsAlive; }
    }
    public bool HasStamina
    {
        get { return this.Stamina > 0; }
    }
    public bool HasFlame
    {
        get { return this.Flame > 0; }
    }

    public void ChangeFlame(float add)
    {
        // A main function to deal with Flame (Fire breathe fuel) change
        this.Flame = Mathf.Clamp(this.Flame + add, 0f, this.MaxFlame);
    }

    public void ChangeStamina(int add)
    {
        // A main function to deal with stamina change
        this.Stamina = Mathf.Clamp(this.Stamina + add, 0, this.MaxStamina);

        // Stamina is monitored by the wings itself, so no need for code here

    }

    private void ChangeHP(int dmg)
    {
        // A main function to deal with HP change
        if (dmg <= 0)
        {
            // Nothing to do here
            //Debug.Log("@@@ " + dmg);
            return;
        }
        

        int HP_Last = this.HP;
        // You will notice, the damage is added...
        this.HP = Mathf.Clamp( this.HP + dmg, -101, this.MaxHP );


        // Check to make sure we didnt just die lol
        if (this.IsDead == true)
        {
            // DEAD
            // @@@Death Hook?


            // Add pushback effect to the dragon body
            RBody.AddForce( new Vector2((float)dmg * -2, (float)Mathf.Sqrt(Mathf.Abs(dmg))) );

            // Timer here
            Ses.DoEnd();

        }
        else
        {
            // Hurt.
            // @@@Sound?
            // We might have to deal with the collision for
            // What we hit
            if (HP_Last > this.HP)
            { // Clearly damage
				// @@@ SOUND HERE
            }
            else if (HP_Last < this.HP)
            { // Clearly heal
				// @@@ SOUND HERE
            }

        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        int dmg = 0; // coll.gameObject.getDamage
        dmg = (int) Mathf.Abs(this.RBody.velocity.magnitude);

        // Please make these globals!!!
        bool IsEnemy = coll.gameObject.tag == "Enemy";
        bool IsItem = coll.gameObject.tag == "Item";
        bool IsWorld = coll.gameObject.tag == "World";

        bool IsOtherDead = (dmg > 5);
        GameObject Other = coll.gameObject;
        
        // coll.gameObject
        // @@@Need flag based on what we hit...

        if (IsEnemy)
        {
            // Its an enemy, so we'll take damage.
            // Damage is NEGATED for simplicity here!!!
            this.ChangeHP(-dmg);
            if (IsOtherDead) { 
                Destroy(Other); // Check me
            }
            this.onGround = true;

        }
        else if (IsItem)
        {
            // @@@

        }
        else if (IsWorld && !this.onGround)
        {
            // Hurt
            this.ChangeHP( -dmg );
            this.onGround = true;
            Debug.Log("DAMAGE ON GROUND: " + dmg);
        }
    }

    void OnCollisionExit2D(Collider coll)
    {
        bool IsEnemy = coll.gameObject.tag == "Enemy";
        bool IsItem = coll.gameObject.tag == "Item";
        bool IsWorld = coll.gameObject.tag == "World";

        if (IsEnemy || IsWorld)
        {
            // Because you cant just take damage on ground
            this.onGround = false;
            Debug.Log("Off ground");
        }
    }

}

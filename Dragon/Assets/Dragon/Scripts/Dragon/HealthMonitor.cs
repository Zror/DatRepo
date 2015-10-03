using UnityEngine;
using System.Collections;

public class HealthMonitor : MonoBehaviour {

    public int HP = 1;
    public int MaxHP = 100;
    public int Stamina = 100;
    public int MaxStamina = 100;
    public float Flame = 5f; // Fuel; Represents burntime in seconds?
    public float MaxFlame = 8f;

    public Collider2D Collison;
    public Rigidbody2D RBody;
    

	// Use this for initialization
	void Start () {

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
	}
	
	// Update is called once per frame
	void Update () {


	}

    void FixedUpdate()
    {
        // In addition to physics...
        // Fixed interval regen will be handled here
        bool flag1 = true;

        if (flag1 && this.Stamina < MaxStamina)
        {
            // Allow Stamina regen (when not in use)
            this.Stamina += 2;
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

        this.ChangeHP(HP_add);
        this.ChangeStamina(Stam_add);
        this.ChangeFlame(Flame_add);


    }

    public bool IsAlive
    { // Attribute
        get { return this.HP > 0; }
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
        
        int HP_Last = this.HP;
        // You will notice, the damage is added...
        this.HP = Mathf.Clamp( this.HP + dmg, -101, this.MaxHP );


        // Check to make sure we didnt just die lol
        if (this.IsAlive)
        {
            // DEAD
            // @@@Death Hook?

            // Add pushback effect to the dragon body
            RBody.AddForce( new Vector2((float)dmg * -2, (float)Mathf.Sqrt(Mathf.Abs(dmg))) );


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
        bool IsEnemy = coll.gameObject.tag == "Enemy";
        bool IsItem = coll.gameObject.tag == "Item";
        
        // coll.gameObject
        // @@@Need flag based on what we hit...

        if (IsEnemy)
        {
            // Its an enemy, so we'll take damage.
            // Damage is NEGATED for simplicity here!!!
            this.ChangeHP( -dmg );
        }
        else if (IsItem)
        {
            // @@@
        }
    }

}

using UnityEngine;
using System.Collections;

public class HealthMonitor : MonoBehaviour {

    public int HP;
    public int MaxHP = 100;
    public int Stamina;
    public int MaxStamina = 100;

    public Collision2D Collison;
    public Rigidbody2D RBody;
    

	// Use this for initialization
	void Start () {
        if (HP == null)
        {
            // If the starting HP is not set, set as total
            // So people dont die RIGHT at start
            HP = MaxHp;

        }
        if (Collison == null)
        {
            Collison = GetComponent<Rigidbody2D>();
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

    public void StatInput(int HP_add, int Stam_add)
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


    }

    public bool IsAlive
    { // Attribute
        get { return HP > 0; }
    }

    private void ChangeStamina(int add)
    {
        // A main function to deal with stamina change
        this.Stamina = Mathf.Clamp(this.Stamina + add, 0, this.MaxStamina);

    }

    private void ChangeHP(int dmg)
    {
        // A main function to deal with HP change
        
        int HP_Last = this.HP;
        // You will notice, the damage is added...
        this.HP = Mathf.Clamp( this.HP + dmg, -101, this.MaxHP );


        // Check to make sure we didnt just die lol
        if (this.IsAlive())
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

            }
            else if (HP_Last < this.HP)
            { // Clearly heal

            }

        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        int dmg = 0; // coll.gameObject.getDamage
        bool flag1 = false; // coll.gameObject
        // @@@Need flag based on what we hit...

        if (flag1)
        {
            this.ChangeHP( -dmg, 0 );
        }
    }

}

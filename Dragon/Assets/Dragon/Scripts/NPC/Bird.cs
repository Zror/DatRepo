using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {

    // Bird needs 0 gravity
    public float Fly_Height;
    private Transform trans;
    public float Rate = 10; // Units/Second
    public int direction; // Going negative or positive x distances?

    public uint give_HP = 4;
    public uint give_Stam = 8;
    public float give_Flame = 3f;

	// Use this for initialization
	void Start () {

        if (Fly_Height == 0f)
        {
            // Establish fly height from where
            // we were spawned in
            this.Fly_Height = getHeight();
            this.direction = getDirection();
        }
		this.give_Flame = Mathf.Max (give_Flame, 0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    // THINK
    void FixedUpdate()
    {
        // Avoid dragons?
        if (Fly_Height != getHeight()+(5*Mathf.Sin(240)))
        {
            float diff = Fly_Height - getHeight();
            // use the difference to assess direction to go
            adjsustHeight(diff);
            // @@@ Forward Motion
        }
    }

    public int getDirection()
    {
        // Returns only the x-direct as -1,0,1
        Transform temp = GetComponent<Transform>();
        float cur = temp.position.x;
        int ans = (int)(Mathf.Abs(cur) / cur);

        return ans;
    }


    public float getHeight()
    {
        float ans = 0f;

        Transform temp = GetComponent<Transform>();
         ans = temp.position.y;


        return ans;
    }
    public void adjsustHeight(float dist)
    {
        // @@@ Sync wing flap animation!
        if (dist == 0) { return; }; // Get out.

        dist = Mathf.Clamp(dist, -1*DistPerTick(), DistPerTick()); // Make sure were not moving too far too fast

        Transform temp = GetComponent<Transform>();

        temp.position.Set(  temp.position.x,
                            temp.position.y + dist,
                            temp.position.z);

    }
    public float DistPerTick(){
        int TicksPerSecond = 60;
        return this.Rate/TicksPerSecond;
    }
    // Check for deaths
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == Globals.TAGS.Player)
        {
            GameObject dragon = coll.gameObject;

            this.PreDeath(dragon); // Use this for when birds hit walls
        }
        Destroy(this.gameObject);
    }

    void PreDeath(GameObject attacker)
    {
        // The bird is ABOUT TO DIE
        // Award your bonus to the Dragon
        HealthMonitor dragonSM = attacker.GetComponent<HealthMonitor>();


		dragonSM.StatInput( this.give_HP,
                            this.give_Stam,
                            this.give_Flame );
        // Maybe do a little animation?

    }
}

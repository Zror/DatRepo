using UnityEngine;
using System.Collections;

public class updraft_area : MonoBehaviour {

	public float Updraft_Amount = 10f;
    private float Force_From_Area;
	public bool Is_Ignited	= false;
	private Vector2[] Size_Bounds = new Vector2[2];
	private Vector2 Position;

	public LayerMask mask;

	// Use this for initialization
	void Start () {
		if (Updraft_Amount < 0f) {
			this.Updraft_Amount = 0f;
		}
		GetSizeBounds ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Called on physics
	void FixedUpdate(){

		if (this.Is_Ignited) {
			Updraft();
		}
	}

	void Updraft(){
        // Might need to make a trigger layer attached to this

        // Search
        Bounds b = this.gameObject.GetComponent<Bounds>();
        Vector2 area = new Vector2();

		Collider2D[] temp = Physics2D.OverlapAreaAll (Size_Bounds[0], Size_Bounds[1], this.mask);

		foreach (var Collider in temp) {
			Rigidbody2D cur = Collider.gameObject.GetComponent<Rigidbody2D>();
			cur.AddForceAtPosition(new Vector2(0, Updraft_Amount), this.transform.position );

		}

		//
	}

	void OnTriggerEnter2D(Collider2D other) {
		bool IsPlayer 	= (other.gameObject.tag == "Player");
		bool IsFire = (other.gameObject.tag == "Fire");


		if (IsFire) {
			this.StartIgnition ();
		} else if (IsPlayer) {
			// We're getting smashed!
			this.Destroy();
		}
	}

	void StartIgnition(){
		// Start the ignition of this field or town
		this.Is_Ignited = true;

		// Sounds and animations stuff


	}

	void Destroy(){
		// Show a smashed city via anim
		// Dont actually remove self!


	}

	Vector2[] GetSizeBounds(){
        // Return the global position of the Transform obj
        Vector2[] ans = new Vector2[2];


		Transform trans = GetComponent<Transform>();
		// Do some positional math
		Vector3 center = trans.position;
		Vector3 scale = trans.lossyScale;

        float leftx = center.x - scale.x;
        float rightx = center.x + scale.x;
        Vector2 left = new Vector2 (leftx, 0);
		Vector2 right = new Vector2 (rightx, center.y + Updraft_Amount);
		

		// Ship out the answer for X points
		ans [0] = left;
		ans [1] = right;

		this.Position = new Vector2 (center.x, center.y);
		this.Size_Bounds = ans;
        this.Force_From_Area = rightx - leftx;

		return ans;
	}
}

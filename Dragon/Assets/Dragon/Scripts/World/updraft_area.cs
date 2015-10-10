using UnityEngine;
using System.Collections;

public class updraft_area : MonoBehaviour {

	public float Updraft_Amount = 10f;
	public bool Is_Ignited	= false;
	private float[] Size_Bounds = new float[2]();
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
		Collider2D[] temp = Physics2D.OverlapAreaAll (Size_Bounds [0], Size_Bounds [1], this.mask);

		foreach (var Collider in temp) {
			Rigidbody2D cur = Collider.gameObject.GetComponent<Rigidbody2D>();
			cur.AddForceAtPosition(new Vector2(0, Updraft_Amount), );

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

	float[] GetSizeBounds(){
		// Return the global position of the Transform obj
		float[] ans;


		Transform trans = GetComponent<Transform>();
		// Do some positional math
		Vector3 center = trans.position;
		Vector3 scale = trans.lossyScale;


		Vector2 left = new Vector2 (center.x - scale.x, center.y + scale.y);
		Vector2 right = new Vector2 (center.x - scale.x, center.y + scale.y);
		

		// Ship out the answer
		ans [0] = left;
		ans [1] = right;
		this.Position = new Vector2 (center.x, center.y);
		this.Size_Bounds = ans;
		return ans;
	}
}

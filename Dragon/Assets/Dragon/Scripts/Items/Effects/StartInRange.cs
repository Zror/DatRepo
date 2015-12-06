using UnityEngine;
using System.Collections;

public class StartInRange : MonoBehaviour {

    public float min;
    public float max;

	// Use this for initialization
	void Start () {
        this.transform.position = new Vector3(this.transform.position.x, Random.Range(min, max), this.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

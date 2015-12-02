using UnityEngine;
using System.Collections;

public class CoinSpin : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
        this.transform.Rotate(Vector3.up, (this.transform.position.x + (this.transform.position.y / 8)) * speed);
    }
	
	// Update is called once per frame
	void Update () {
	    this.transform.Rotate(Vector3.up, Time.deltaTime * speed);
	}
}

using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject follow;
	public float followSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 position = new Vector3(Mathf.Lerp(this.transform.position.x, follow.transform.position.x, followSpeed * Time.fixedDeltaTime),
			Mathf.Lerp(this.transform.position.y, follow.transform.position.y, followSpeed * Time.fixedDeltaTime),
			this.transform.position.z);
		
		this.transform.position = position;
	}
}

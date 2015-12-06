using UnityEngine;
using System.Collections;

public class CameraMoveRight : MonoBehaviour
{
    public float speed = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	    this.transform.position += Vector3.right*Time.deltaTime*speed;
	}
}

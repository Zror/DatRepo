using UnityEngine;
using System.Collections;

public class Balloon : MonoBehaviour {
    public GameObject[] objects;
	// Use this for initialization
	void Start () {
        Random.seed= System.DateTime.Now.Millisecond;
        int position = Random.Range(0, objects.Length);
        Instantiate(objects[position], new Vector3(transform.position.x, transform.position.y - 2), Quaternion.Euler(0, 0, 0));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;

public class SceneTransition2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Input.simulateMouseWithTouches = true;
    }
    public void onClick(int index)
    {
        Application.LoadLevel(index);
    }
}

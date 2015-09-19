using UnityEngine;
using System.Collections;

public class Avenuebutton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
 
    public void onClick(string name)
    {
        if (name.Equals("Tutor"))
        {
            Application.LoadLevel(1);
        }
        else if (name.Equals("Magic"))
        {
            Application.LoadLevel(2);
        }
        else if (name.Equals("Disguise"))
        {
            Application.LoadLevel(3);
        }
    }
}

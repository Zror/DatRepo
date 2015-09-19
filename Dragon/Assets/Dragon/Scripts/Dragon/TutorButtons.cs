using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorButtons : MonoBehaviour {

    // Use this for initialization
    public int gold;
    bool flight;
    bool fire;
	void Start () {
        gold = 0;
        fire = false;
        flight = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void onClick(string Arg)
    {
        if (Arg.Equals("Back"))
        {
            Application.LoadLevel(0);
        }
        else if (Arg.Equals("Flight"))
        {
            gold = gold - 20;
        }
    }
}

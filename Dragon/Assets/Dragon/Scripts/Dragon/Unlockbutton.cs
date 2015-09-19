using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Unlockbutton : MonoBehaviour {
    public Unlockable unlock;
    public Button butt;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (unlock.IsUnlocked)
        {
            butt.interactable = true;
        }
	}
    public void onClick(string arg)
    {
        if (arg.Equals("Flight"))
        {
            unlock.IsUnlocked = false;
            butt.interactable = false;
        }
        else if (arg.Equals("Flame"))
        {
            unlock.IsUnlocked = false;
            butt.interactable = false;
        }
    }
}

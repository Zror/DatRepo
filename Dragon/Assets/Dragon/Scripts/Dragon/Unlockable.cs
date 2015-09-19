using UnityEngine;
using System.Collections;

public class Unlockable : MonoBehaviour {
    private bool Unlocked;
    public Unlockable parent;

    public bool IsUnlocked
    {
        get {
            return Unlocked;
        }

        set {
            if (Unlocked!=value)
                Unlocked = value;
        }
    }

	// Use this for initialization
	void Start () {
        if (parent == null)
        {
            Unlocked = true;
        }
        else
        {
            Unlocked = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (parent!=null && !parent.IsUnlocked)
        {
            Unlocked = true;
        }
	}
}

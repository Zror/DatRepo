using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoldBehavior : MonoBehaviour {
    public Text t;
    private uint gold;
	// Use this for initialization
	void Start () {
        gold = 100;
	}
	
	// Update is called once per frame
	void Update () {
        t.text = "Current Gold: " + gold;
	}
    public uint get()
    {
        return gold;
    }
    public void change(uint c)
    {
        gold += c;
    }
    public void lose(uint c)
    {
        gold -= c;
    }
}

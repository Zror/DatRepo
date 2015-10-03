using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoldBehavior : MonoBehaviour {
    public Text t;
    private int gold;
	// Use this for initialization
	void Start () {
        gold = 100;
	}
	
	// Update is called once per frame
	void Update () {
        t.text = "Current Gold: " + gold;
	}
    public int get()
    {
        return gold;
    }
    public void change(int c)
    {
        gold += c;
    }
}

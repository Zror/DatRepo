using UnityEngine;
using System.Collections;

public class GoldBehavior : MonoBehaviour {
    private int gold;
	// Use this for initialization
	void Start () {
        gold = 100;
	}
	
	// Update is called once per frame
	void Update () {
	
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

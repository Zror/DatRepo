using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoldTextBehavior : MonoBehaviour {
    public xmlSavingClass save;
    public SavedData gold;
    public Text t;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        gold = save.stats;
        t.text = "Current Gold: " + gold.get();
    }
}

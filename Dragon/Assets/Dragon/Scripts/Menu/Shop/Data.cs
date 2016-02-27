using UnityEngine;
using System.Collections;

public class Data : MonoBehaviour {
    private SavedData Stats;
    public xmlLoadingClass load;
    public bool loaded;
	// Use this for initialization
	void Start () {
        //this.Stats = null;
        //loaded = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void setStats(SavedData s)
    {
        Stats = s;
        loaded = true;
    }
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    public SavedData get()
    {
        return Stats;
    }
    public void updateThings(uint gold, int p)
    {
        Stats.gold += gold;
        Stats.princess_captured += p;
    }
}

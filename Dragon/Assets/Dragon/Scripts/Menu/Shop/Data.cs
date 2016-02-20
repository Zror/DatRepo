using UnityEngine;
using System.Collections;

public class Data : MonoBehaviour {
    private SavedData Stats;
    public xmlLoadingClass load;
	// Use this for initialization
	void Start () {
        this.Stats = load.stats;
	}
	
	// Update is called once per frame
	void Update () {
	
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

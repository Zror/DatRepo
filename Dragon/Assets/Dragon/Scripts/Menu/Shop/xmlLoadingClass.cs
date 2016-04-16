using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.IO;

public class xmlLoadingClass : MonoBehaviour {
    private const string ADDRESS = "savedData";
    protected XmlSerializer serialize = new XmlSerializer(typeof(SavedData));
    public SavedData stats;
    
    // Use this for initialization
    void Start () {



        //DELETE THIS BEFORE RELEASE
        





        Data temp = GameObject.FindGameObjectWithTag("Load").GetComponent<Data>();
        Debug.Log("1");
        if (!temp.loaded)
        {
            Debug.Log("2");
            string s = PlayerPrefs.GetString(ADDRESS, "FIRST!");
            Debug.Log(s);
            if (!s.Equals("FIRST!"))
            {
                
                StringReader status = new StringReader(s);
                stats = (SavedData)serialize.Deserialize(status);
                Debug.Log(stats.gold);
            }
            else
            {
                stats = new SavedData();
                Debug.Log("no");
            }
            temp.setStats(stats);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    
}

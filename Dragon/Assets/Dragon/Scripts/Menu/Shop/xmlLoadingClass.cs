using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.IO;

public class xmlLoadingClass : MonoBehaviour {
    private const string ADDRESS = "savedData";
    protected XmlSerializer serialize = new XmlSerializer(typeof(SavedData));
    public SavedData stats = new SavedData();
    
    // Use this for initialization
    void Start () {
        //PlayerPrefs.DeleteAll();
        string s = PlayerPrefs.GetString(ADDRESS, "FIRST!");
        if (!s.Equals("FIRST!"))
        {

            StringReader status = new StringReader(s);
            stats = (SavedData)serialize.Deserialize(status);
        }
        else
        {
            stats = new SavedData();
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    
}

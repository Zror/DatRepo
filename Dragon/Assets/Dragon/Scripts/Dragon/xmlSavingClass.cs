using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.IO;

public class xmlSavingClass : MonoBehaviour {
    private const string ADDRESS = "savedData";
    protected XmlSerializer serialize = new XmlSerializer(typeof (SavedData));
    public SavedData stats=new SavedData();
	// Use this for initialization
	void Start () {
        string s = PlayerPrefs.GetString(ADDRESS, "FIRST!");
        if (!s.Equals("FIRST!"))
        {
            
            StringReader status = new StringReader(s);
            stats = (SavedData)serialize.Deserialize(status);
        }

	}
	
	// Update is called once per frame
	void Update () {
    }
    public void Save()
    {
        TextWriter text = new StringWriter();
        serialize.Serialize(text, stats);
        Debug.Log(text);
        PlayerPrefs.SetString(ADDRESS,text.ToString());
        PlayerPrefs.Save();
    }
}

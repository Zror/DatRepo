using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.IO;

public class xmlSavingClass : MonoBehaviour {
    private const string ADDRESS = "savedData";
    protected XmlSerializer serialize = new XmlSerializer(typeof (SavedData));
    public SavedData stats;
	// Use this for initialization
	void Start () {

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
    void Awake()
    {
       Data temp=GameObject.FindGameObjectWithTag("Load").GetComponent<Data>();
        if (temp == null)
        {
            Debug.Log("Failed");
        }
        else
        {
            Debug.Log("Success");
            this.stats = temp.get();
            TextWriter text = new StringWriter();
            serialize.Serialize(text, stats);
            Debug.Log(text);
        }
    }
}

using UnityEngine;
using System.Collections;

public class Selector : MonoBehaviour {

    public GameObject[] skins;
    public GameObject[] wings;
    int skinSelected;
    int wingSelected;
    // Use this for initialization
    void Start()
    {
        Session_Monitor session = FindObjectOfType<Session_Monitor>();
        skinSelected = session.getSkins();
        wingSelected = session.getWings();
        var skin = (GameObject)Instantiate(skins[skinSelected], gameObject.transform.position, gameObject.transform.rotation);
        var wing = (GameObject)Instantiate(wings[wingSelected], gameObject.transform.position, gameObject.transform.rotation);
        skin.transform.parent = gameObject.transform;
        wing.transform.parent = gameObject.transform;
    }

    // Update is called once per frame
    void Update () {
	
	}
}

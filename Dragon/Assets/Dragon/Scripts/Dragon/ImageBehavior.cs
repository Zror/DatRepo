using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageBehavior : MonoBehaviour {
    public int index = 0;
    private int[] images={1,2,3,4,5,6,7,8,9,10};
    public Button butt;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Text t = butt.GetComponentInChildren<Text>();
        t.text = images[index]+"\n"+images[index]+"\n"+images[index]+"\n"+images[index];
    }
}

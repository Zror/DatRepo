using UnityEngine;
using System.Collections;

public class ArrowBehavior : MonoBehaviour {
    public ImageBehavior image;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void onClick(string arg)
    {
        if(arg.Equals("<"))
        {
            if (image.index != 0)
            {
                image.index--;
            }
        }
        else if (arg.Equals(">"))
        {
            if (image.index != 9)
            {
                image.index++;
            }
        }
    }
}   

using UnityEngine;
using System.Collections;

public class ArrowBehavior : MonoBehaviour {
    public ImageBehavior image;
    private int max_size;
	void Start () {
        max_size = image.images.Length-1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void onClick(string arg)
    {
        if(arg.Equals("<"))
        {
            if (image.current != 0)
            {
                image.current--;
            }
        }
        else if (arg.Equals(">"))
        {
            if (image.current != max_size)
            {
                image.current++;
            }
        }
    }
}   

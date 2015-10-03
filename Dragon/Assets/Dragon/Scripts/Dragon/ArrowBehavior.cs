﻿using UnityEngine;
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
            if (image.index != 0)
            {
                image.index--;
            }
        }
        else if (arg.Equals(">"))
        {
            if (image.index != max_size)
            {
                image.index++;
            }
        }
    }
}   

﻿using UnityEngine;
using System.Collections;

public class BackButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Back"))
        {
            Application.LoadLevel("Shop-avenue.unity");
        }
    }
    void onClick(){
         Application.LoadLevel("Shop-avenue.unity");
    }
}
﻿using UnityEngine;
using System.Collections;

public class night : MonoBehaviour {
    public bool Walk;
    private Animator ani;
    // Use this for initialization
    void Start () {
        ani = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        ani.SetBool("Walk", Walk);
    }
}

﻿using UnityEngine;
using System.Collections;

public class Base_Livestock : MonoBehaviour {

    public uint range = 0;
    public uint rate = 0; // per second
    public bool direction = false; // 1 left, 0 right
    private Transform move;
    private float covered = 0;

    // PLAY sounds too!

	// Use this for initialization
	void Start () {
	    if (range == 0)
        {
            this.range = (uint)((Random.value+0.5)*15);

        }
        if (rate == 0)
        {
            this.rate = (uint)((Random.value+0.05) * 3);
        }
        this.move = this.GetComponent<Transform>();
	}
	
    void FixedUpdate()
    {
        // MOOve
        if (this.range == 0)
        {
            // Just dont..
            return;
        }

        float arg = ((float)(this.rate) / 60);
        if (direction)
        {
            arg *= -1;
        }
        this.move.position = new Vector3(move.position.x + arg, move.position.y, move.position.z);
        this.covered += arg;

        if ( this.covered == range || this.covered == range * -1)
        {
            // Toggle direction
            this.direction = !this.direction;
        }
    }

    void PlayLiveStockSound()
    {
        // @@@CODE HERE!
    }
}

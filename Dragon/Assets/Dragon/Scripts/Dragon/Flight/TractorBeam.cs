﻿using UnityEngine;
using System.Collections;

public class TractorBeam : Flight {
    private float scalar = .1F;
    private float down = 5F;
    // Update is called once per frame
    public override void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(new Vector2(velocity * .55F, -velocity * down ));
        }

        rigidbody.AddForce(new Vector2(0,scalar * velocity));
    }

}

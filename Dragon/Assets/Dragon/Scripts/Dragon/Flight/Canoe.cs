using UnityEngine;
using System.Collections;

public class Canoe : Flight {

    public override void Start()
    {
        base.Start();
        rigidbody.gravityScale = 0;
    }
    // Update is called once per frame
    public override void Update () { 
       
    }
}

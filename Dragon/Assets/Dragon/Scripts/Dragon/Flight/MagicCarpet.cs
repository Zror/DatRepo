using UnityEngine;
using System.Collections;

public class MagicCarpet : Flight {

    public float grav = .5F;

    private float scalar = .2F;

    public override void Start()
    {
        base.Start();
        rigidbody.gravityScale = rigidbody.gravityScale * grav;
        velocity = (velocity * scalar);

       
    }
}

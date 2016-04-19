using UnityEngine;
using System.Collections;

public class TractorBeam : Flight {
    private float scalar = .1F;
    private float down = 5F;
    // Update is called once per frame
    public override void Update () {
        if (Input.GetMouseButtonDown(0) && health.HasStamina && clickLeft())
        {
            rigidbody.AddForce(new Vector2(velocity, -velocity * down ));
            health.ChangeStamina(-1);
        }

        rigidbody.AddForce(new Vector2(0,scalar * velocity));
    }

}

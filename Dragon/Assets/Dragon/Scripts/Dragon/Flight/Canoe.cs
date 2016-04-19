using UnityEngine;
using System.Collections;

public class Canoe : Flight {
    float freq;
    public override void Start()
    {
        freq = 5.0f;
        base.Start();
        rigidbody.gravityScale = 0.1f;
    }
    // Update is called once per frame
    public override void Update () {

        if (freq <= 0)
        {
            Random.seed = System.DateTime.Now.Millisecond;
            rigidbody.gravityScale = (Random.Range(0, 100)) / 100.0f;
            freq += 5;
        }
        freq -= Time.deltaTime;

        if(Input.GetMouseButtonDown(0) && health.HasStamina && clickLeft())
        {
            rigidbody.AddForce(new Vector2(velocity * 1.5F, velocity * .75F));
            health.ChangeStamina(-1);
        }
    }
}

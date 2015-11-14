using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]
public class AttackBase : MonoBehaviour {
    Rigidbody2D body;
    public int angle;
    public Sprite imageName;
    public int length;
    public int width;
    public bool spec1;
    public bool spec2;
    public GameObject Dragon;
    public int speedAddition;
    int speed;
    // Use this for initialization
    void Start () {
        speed=Dragon.g
        body = GetComponent<Rigidbody2D>();
        float angle = transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        body.velocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * speed;
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(body.velocity.y, body.velocity.x) * Mathf.Rad2Deg);
    }
}

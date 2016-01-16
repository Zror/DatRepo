using UnityEngine;
using System.Collections;

public class AutoAim : MonoBehaviour {
    Vector3 point1;
    Vector2 point2;
    float dy;
    float dx;
    GameObject dragon;
    // Use this for initialization
    void Start() {
        dragon = GameObject.Find("Dragon");
        point1 = dragon.transform.position;
    }
	// Update is called once per frame
	void Update () {
        point2 = point1;
        point1 = dragon.transform.position;
        dy = (point1.y - point2.y);
        dx = (point1.x - point2.x);
	}
    private float arcTan(float time, float x, float y)
    {
        float xx = ((point2.x - x) + (dx * time));
        float yy = ((point2.y - y) + (dy * time));
        return (Mathf.Atan2(yy,xx) * Mathf.Rad2Deg);

    }
    private float time(float x, float y, float speed)
    {
        float dist = Mathf.Sqrt((point1.x-x)* (point1.x - x)+ (point1.y - y) * (point1.y -y));
        return dist / speed;
    }
    public float angle(float x, float y, float speed)
    {
        float t1 = time(x, y, speed);

        //        float a2 = arcTan(t1, x, y);
        //
        //        float t2 = Mathf.Cos(a2 * Mathf.Deg2Rad) * speed / time;

        //        float a3 = arcTan(t2, x, y);

        //        float t3 =  (Mathf.Cos(a3 * Mathf.Deg2Rad) * speed / time);

        return arcTan(t1, x, y) - 17;


    }
}

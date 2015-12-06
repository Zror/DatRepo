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
    public float angle(float x, float y, float speed, float time)
    {
        float t1 =Mathf.Cos(45*Mathf.Deg2Rad) * speed / time;
        float a2 = arcTan(t1, x, y);
        float t2 = Mathf.Cos(a2 * Mathf.Deg2Rad) * speed / time;
        float a3 = arcTan(t2, x, y);
        float t3 = 180 - (Mathf.Cos(a3 * Mathf.Deg2Rad) * speed / time);
        return arcTan(t3, x, y);


    }

}

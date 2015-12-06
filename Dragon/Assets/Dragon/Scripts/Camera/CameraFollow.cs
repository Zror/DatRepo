using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour {


	public GameObject follow;
	public float followSpeed;
    Vector3 position;
    protected new Camera camera;
    public int top = 30;
    public int bottom = 0;
    // Use this for initialization
    void Start () {
        camera = GetComponent<Camera>();
    }
	
    // Update is called once per frame
    void FixedUpdate () {
       
       
            position = new Vector3(Mathf.Lerp(this.transform.position.x, follow.transform.position.x, followSpeed * Time.fixedDeltaTime),
            Mathf.Lerp(this.transform.position.y, follow.transform.position.y, followSpeed * Time.fixedDeltaTime),
            this.transform.position.z);
        
    if(position.y + camera.orthographicSize > top)
        {
            position.y = top - camera.orthographicSize;
        }else
            if (position.y - camera.orthographicSize < bottom)
        {
            position.y = bottom + camera.orthographicSize;
        }
        position.x = follow.transform.position.x + (.9F*(camera.orthographicSize * camera.aspect ));
            this.transform.position = position;
	}
}

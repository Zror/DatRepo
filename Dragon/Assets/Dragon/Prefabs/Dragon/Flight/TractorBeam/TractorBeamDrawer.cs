using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class TractorBeamDrawer : MonoBehaviour {

    LineRenderer render;
    public Vector3 mod;
    // Use this for initialization
    void Start () {
        render = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        var dragonPos = transform.position;
        render.SetPosition(0, dragonPos + mod);
        render.SetPosition(1, dragonPos - mod);
	}
}

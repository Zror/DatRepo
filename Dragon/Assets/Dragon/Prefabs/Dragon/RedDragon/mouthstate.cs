using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Animator))]
public class mouthstate : MonoBehaviour {
    public bool OpenMouth;
    private Animator ani;
    void Start () {
        ani = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        ani.SetBool("OpenMouth", OpenMouth);
	}
}

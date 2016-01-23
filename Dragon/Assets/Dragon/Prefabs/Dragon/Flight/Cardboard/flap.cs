using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Animator))]
public class flap : MonoBehaviour
{
    public bool OpenMouth;
    public bool Jump;
    public bool Hit;
    private Animator ani;
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ani.SetBool("Jump", Jump);
        ani.SetBool("OpenMouth", OpenMouth);
        ani.SetBool("Hit", Hit);
    }
}
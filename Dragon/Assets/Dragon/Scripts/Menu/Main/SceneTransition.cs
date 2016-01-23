using UnityEngine;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public Animator animator;

    private int transitionTo;
    private bool transitioning;

    public void BeginTransition(int target)
    {
        if (!transitioning)
        {
            transitioning = true;
            transitionTo = target;

            animator.SetBool("PlayGame", transitioning);
            animator.SetInteger("LevelId", transitionTo);
        }
    }
}

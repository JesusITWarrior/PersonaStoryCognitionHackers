using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconBehavior : MonoBehaviour
{
    [SerializeField] private bool spin, slowFadeIn;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Spin", spin);
        if (slowFadeIn)
            animator.Play("Slow Fade In");
    }

    public void fadeOut()
    {
        animator.SetTrigger("FadeOut");
    }
}

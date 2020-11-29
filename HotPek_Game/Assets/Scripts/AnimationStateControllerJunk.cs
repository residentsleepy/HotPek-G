using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateControllerJunk : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool("IsWalking");
        bool pressW = false;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if(horizontal != 0 || vertical != 0)
        {
            pressW = true;
        }

        if (!isWalking && pressW)
        {
            animator.SetBool("IsWalking", true);
        }
        if (isWalking && !pressW)
        {
            animator.SetBool("IsWalking", false);
        }
    }
}

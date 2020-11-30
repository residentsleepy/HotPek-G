using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
//  Controlador de animaciones, según que acción realice Junk
//  la animación se dispara en nuestro árbol de estados
//

public class AnimationStateControllerJunk : MonoBehaviour
{
    // Variable la cual usaremos para acceder al Animator del Objeto
    Animator animator;
    
    void Start()
    {
        //Obtenemos el animador del objeto
        animator = GetComponent<Animator>();
    }

   
    void Update()
    {
        // Variable para guardar el estado en el que se encuentra nuestro árbol de animación
        bool isWalking = animator.GetBool("IsWalking");
        bool isRunning = animator.GetBool("IsRunning");
        bool pressW = false;
        bool pressShift = Input.GetKey("left shift");
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

        if (!isRunning && (pressShift && isWalking))
        {
            animator.SetBool("IsRunning", true);
        }
        if (isRunning && (!isWalking || !pressShift))
        {
            animator.SetBool("IsRunning", false);
        }
    }
}

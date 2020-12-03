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
        // Variables para guardar las variables que se encuentran nuestro árbol de animación
        bool isWalking = animator.GetBool("IsWalking");
        bool isRunning = animator.GetBool("IsRunning");
        bool isHiding = animator.GetBool("IsHiding");
        // variables para nuestros inputs
        bool pressW = false;
        bool pressSpace = Input.GetKey("space");
        bool pressShift = Input.GetKey("left shift");
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // si nuestras entradas en el axis Horizontal y vertical NO son 0, estamos apretnado W
        if(horizontal != 0 || vertical != 0)
        {
            pressW = true;
        }

        //Si No estaba caminando y Preto W
        if (!isWalking && pressW)
        {
            //Cambio al estado de  caminado
            animator.SetBool("IsWalking", true);
        }
        // Si ya estaba caminando y no apreto W
        if (isWalking && !pressW)
        {
            // Dejo el estado de Caminado
            animator.SetBool("IsWalking", false);
        }
        // Si no estaba corriendo Y apreto Shift Y ya estaba caminando
        if (!isRunning && (pressShift && isWalking))
        {
            //Cambio al estado de correr
            animator.SetBool("IsRunning", true);
        }
        //Si ya estaba corriendo y dejo de caminar O apretar Shift
        if (isRunning && (!isWalking || !pressShift))
        {
            //Dejo el estado de correr
            animator.SetBool("IsRunning", false);
        }
        // Si no me estoy escondiendo Y apreto Espacio Y mi Tag No es "Player"
        if(!isHiding && (pressSpace && this.gameObject.tag != "Player"))
        {
            //Cambio al estado de escondido 
            animator.SetBool("IsHiding", true);
        }
        // Si me estoy escondiendo Y no aprieto Espacio O mi Tag es Player
        if(isHiding && (!pressSpace || this.gameObject.tag == "Player"))
        {
            //Dejo el estado de escondido 
            animator.SetBool("IsHiding", false);
        }
    }
}

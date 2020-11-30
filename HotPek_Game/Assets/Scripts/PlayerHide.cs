using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//
// El objetivo de este script es hacer invisible al jugador
// ante los enemigos, utilizando las Tags de Unity y triggers
// Cuando un objeto tenga el Tag "Hide", el jugador podra preccionar "jump" 
// para poder esconderse.
//

public class PlayerHide : MonoBehaviour
{
    //variable bandera para saber si podemos escondernos 
    bool flagHide = false;
    
    void Update()
    {
        //Comprobamos si el boton de esapcio se mantiene presionado y el objeto de colision tiene tag "hide"
        if (Input.GetButton("Jump") &&  flagHide == true)
        {
            Debug.Log("cambiando tag");
            gameObject.tag = "Untagged";
        }
    }
    //comprobamos que el objeto que activa el trigger es un objeto de tipo Hide con su tag
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Hide")
        {
            flagHide = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Hide")
        {
            flagHide = false;
            gameObject.tag = "Player";
        }
        if(collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("Menu");
        }
        
    }
}

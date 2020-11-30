using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    //ESTE CÓDIGO VA EN EL PERSONAJE U OBJETO QUE TENGA ALGÚN DIALOGO

    //Este codigo regula las interacciones del jugador con cualquier otro personaje u objeto que tenga dialogo, entregandole sus lineas
    //al Dialogue Manager para que pueda mostrarlas en pantalla.

    public Dialogue dialogue; //Usamos está clase para determinar el nombre y dialogo(s) del objeto/personaje
    private float charSpeed; //Usamos este float para guardar la velocidad original del jugador
    
    //Con esto hacemos referencia al Dialogue Manager para realizar el trabajo con los dialogos
    void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue); //Llamamos a la función de dialogo dentro del DialogueManager
    }

    //Cuando se causa un trigger en el objeto...
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") //Primero necesitamos determinar si el trigger fue causado por el jugador
        {
            charSpeed = other.GetComponent<PlayerController>().speed; //Guardamos el valor original de la velocidad del jugador
            other.GetComponent<PlayerController>().speed = 0f; //Después de guardarlo lo hacemos 0 para evitar que se mueva durante el dialogo
            TriggerDialogue(); //Llamamos la función para empezar el dialogo
            FindObjectOfType<DialogueManager>().ReturnSpeed(charSpeed); //Le devolvemos la velocidad al jugador
        }
    }
}

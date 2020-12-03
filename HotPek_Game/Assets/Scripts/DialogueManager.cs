using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    //ESTE CODIGO VA EN EL OBJETO DIALOGUE MANAGER

    //Con este código controlamos las oraciones de una personaje u objeto, así como el momento en que aparecen y desaparecen en pantalla

    public TextMeshProUGUI nameText; //Cuadro de Texto de la UI donde aparecerá el nombre del objeto/personaje
    public TextMeshProUGUI dialogueText; //Cuadro de Texto de la UI donde aparecerán los dialogos
    public Animator animator; //El Animator es usado para controlar cuando aparecen los cuadros de texto en pantalla
    private Queue<string> sentences; //Usamos esta queue para controlar como aparece el texto

    void Start()
    {
        animator.SetBool("IsOpen", false);
        sentences = new Queue<string>(); //Creamos la queue que nos servirá en las funciones de los dialogos
    }


    //Esta función es la usada para mostrar nuestros dialogos en pantalla usando el Animator
    //Se usa el Dialogue como parametro para tener los nombres y oraciones definidos
    public void StartDialogue(Dialogue dialogue)
    {
        //Establecemos el booleano que usa el Animator como true para que aparezca en pantalla
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name; //Se define el texto para el nombre
        sentences.Clear(); //Libramos la queue
        //Este ciclo es usado para guardar cada sentence que aparecerá
        foreach (string sentence in dialogue.sentences)
        {
            FindObjectOfType<AudioManager>().Play("BoxSound");
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence(); //Llamamos a esta función para mostrar la siguiente oración
    }


    //Esta función se utiliza para mostrar los dialogos disponibles para el objeto/personaje, mostrandolos poco a poco
    public void DisplayNextSentence()
    {
        //Primero se determina si ya no hay más oraciones para mostrar
        if (sentences.Count == 0)
        {
            FindObjectOfType<AudioManager>().Play("BoxSound");
            //En caso de no tener mas oraciones llamamos a la función que termina los dialogos
            EndDialogue();
            //Y le devolvemos al jugador su velocidad original
            return;
        }
        //LINEA DESHABILITADA //Se usará si le ponemos sonido a los dialogos
        /*
        FindObjectOfType<AudioManager>().Play("VoiceSound");
        */
        string sentence = sentences.Dequeue(); //Si aún tenemos oraciones las sacamos de queue
        StopAllCoroutines(); //Se paran las corrutinas previas (causadas por anteriores oraciones)
        StartCoroutine(TypeSentence(sentence)); //Y creamos una nueva corrutina para mostrar la oración actual
    }


    //Este IEnumerator es usado para mostrar letra por letra las oraciones que teníamos en la queue
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray()) //Aqui convertimos las oraciones en caracteres
        {
            dialogueText.text += letter; //El texto se va actualizando con cada caracter que tenemos en las oraciones
            yield return null;
        }
    }

    //Si no quedan más oraciones entonces podemos cerrar el cuadro de dialogo del UI
    void EndDialogue()
    {
        animator.SetBool("IsOpen", false); //Se determinar el booleano del Animator como falso para guardarlo
    }


    //Con este sencillo código devolvemos la velocidad al jugador
    public void ReturnSpeed(float charSpeed)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().speed = charSpeed;
    }
}

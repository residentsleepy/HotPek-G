using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //ESTE CODIGO VA EN EL OBJETO O PERSONAJE QUE TENGA DIALOGO

    public Dialogue dialogue; //Esto nos da nuestros dialogos, solo hay que incluir el codigo Dialogue en el espacio y definirlos
    public Text nameText; //Este cuadro de texto es donde saldrá el nombre del Objeto/Personaje
    public Text dialogueText; //Este cuadro de Texto es donde saldrán las oraciones
    public Animator animator; //El animator que usaremos para mostrar el dialogo
    private Queue<string> sentences; //Las oraciones
    private float charSpeed; //Este valor nos sirve para guardar el valor original de la velocidad del jugador


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //En esta acción cuando el jugador hace contacto con el objeto su velocidad se reduce para reprodcuir el dialogo.
    void OnTriggerEnter(Collider other)
    {
        //Cambiar el tag si el jugador usa uno diferente
        if (other.tag == "Player")
        {
            //Se reduce la velocidad del jugador a cero y guardamos el valor original
            charSpeed = other.GetComponent<PlayerController>().speed;
            other.GetComponent<PlayerController>().speed = 0;
            //Se llama al dialogo
            StartDialogue(dialogue);
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //Se tiene que crear un animador para que esta parte funcione, es lo que hace que el dialogo salga en pantalla
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            //Esta linea es solo si se tiene un sonido, desabilitado por el momento
            /*
            FindObjectOfType<AudioManager>().Play("BoxSound");
            */
            //Se ponen las oraciones en la Queue
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        //Esto pasa cuando ya no hay oraciones
        if (sentences.Count == 0)
        {
            /*
            FindObjectOfType<AudioManager>().Play("BoxSound");
            */
            EndDialogue();
            //Cambiar el Tag si el personaje tiene uno diferente
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().speed = charSpeed;
            return;
        }
        //Esto pasa cuando aun hay oraciones
        /*
        FindObjectOfType<AudioManager>().Play("VoiceSound");
        */
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    //Aqui le decimos al animador que desactive el cuadro de dialogo
    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }

}

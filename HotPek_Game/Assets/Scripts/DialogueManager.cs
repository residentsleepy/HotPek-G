using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //THIS CODE NEEDS TO BE IN A CHARACTER OR OBJECT THAT HAS DIALOGUE

    public Dialogue dialogue; //We use the code for the ability to define a name and multiple sentences for our character or item
    public Text nameText; //UI Text were the name will be shown
    public Text dialogueText; //UI Text were the dialogue will be shown
    public Animator animator; //Necessary Animator for turning on/off the dialogue UI
    private Queue<string> sentences; //We use this for the sentences to show
    private float charSpeed; //This value is used to store the original player character speed


    void Start()
    {
        sentences = new Queue<string>();
    }

    //When the player character approaches we initialize the dialogue
    void OnTriggerEnter(Collider other)
    {
        //First we need to be sure that the trigger is the character
        if (other.tag == "Player")
        {
            //We store the current speed of the character and then set it to zero to prevent movement
            charSpeed = other.GetComponent<PlayerController>().speed;
            other.GetComponent<PlayerController>().speed = 0;
            //Then we call the function to start the dialogue using the values the Dialogue gives us to work
            StartDialogue(dialogue);
        }
    }

    //With this function we show the dialogue in screen using an animator
    //We need a Dialogue as a parameter to define the name and sentences we will show
    public void StartDialogue(Dialogue dialogue)
    {
        //We set the boolean the animator has as true to show it on screen
        animator.SetBool("IsOpen", true);
        //We define the name that will be used
        nameText.text = dialogue.name;
        //We clear our queue
        sentences.Clear();
        //This cycle is used to add setnences to the cleared queue to later show it
        foreach (string sentence in dialogue.sentences)
        {
            //This line is disabilited for the moment, is used to play a sound
            /*
            FindObjectOfType<AudioManager>().Play("BoxSound");
            */
            sentences.Enqueue(sentence);
        }
        //Then we call the next function to show our lines of text
        DisplayNextSentence();
    }


    //This function is used to call the function necessary to tyoe characters on the screen while checking our current sentence
    //To know if the dialogue has ended or not
    public void DisplayNextSentence()
    {
        //If there are no more sentences
        if (sentences.Count == 0)
        {
            //This line is disabilited for the moment, is used to play a sound
            /*
            FindObjectOfType<AudioManager>().Play("BoxSound");
            */
            //We call the EndDailogue function keep playing outside the dialogue
            EndDialogue();
            //We give the character the speed it had before the dialogue
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().speed = charSpeed;
            return;
        }
        //This line is disabilited for the moment, is used to play a sound
        /*
        FindObjectOfType<AudioManager>().Play("VoiceSound");
        */
        //If we still have sentences we need to dequeue them
        //Stoping previous coroutine used for previous sentences and
        //Creating a new coroutine for the current sentence
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }


    //This IEnumerator is used to the display of the text letter by letter of our sentences
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    //When the dialogue has ended we set our Animator's boolean to false to hide it's UI
    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }

}

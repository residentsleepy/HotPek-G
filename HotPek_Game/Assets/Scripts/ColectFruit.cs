using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//THIS CODE BELONGS TO THE CHARACTER, IT NEEDS A BOX COLLIDER TO BE ABLE TO WORK

//This code allow us to check if the character is able to pick up fruit and increase it's score.
//It can be used also to interact with other object by using the Box Collider the character has infront of it

public class ColectFruit : MonoBehaviour
{
    //This represents the collider in front of our character, used for detect interactable objects.
    private BoxCollider colli;
    //Player's score and how much will it increase
    private int score;
    public int scoreBonus = 10;
    //Part is just a placeholder we need, fruit represents the fruit or object we interact with
    private GameObject part, fruit;
    //This allow us to use a particle system for more effects in the game. We manually control it in the Inspector.
    public GameObject particle;
    //We save the position of the last object to cause a trigger
    private Vector3 fruitPos;
    //With this boolean we set if it is posible to collect an object
    private bool collectable = false;
   

    void Start()
    {
        //We set our Box Collider to be used
        colli = GetComponent<BoxCollider>();
        //And we stablish our initial score
        score = 0;
        //This line of code is used to check if the score is correct with each interaction
        Debug.Log("Score: " + score);
    }

    void Update()
    {
        //If we are able to collect we can press the left click to trigger some events:
        if (Input.GetKeyDown(KeyCode.Space) && collectable == true)
        {
            Debug.Log("Space Pressed");
            //The particle system we are using is triggered
            part = Instantiate(particle, fruitPos, Quaternion.identity);
            //Our score goes up
            score += scoreBonus;
            Debug.Log("Score: " + score);
            //And the fruit we collected disappears and our state goes back to being unable to collect
            Destroy(fruit);
            collectable = false;
        }
    }

    //If we have a trigger through our collider...
    //(All interactable objects must have a trigger and Rigibody)
    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("Trigger");
        //If we interact with a fruit
        if (col.gameObject.tag == "Fruit")
        {
            Debug.Log("Trigger with Fruit");
            //We save its position
            fruitPos = col.gameObject.transform.position;
            //Quick check of data
            Debug.Log(col.gameObject.transform.position.x);
            Debug.Log(col.gameObject.transform.position.y);
            Debug.Log(col.gameObject.transform.position.z);
            //We set a variable to have the trigger fruit to be an active element we are interacting with
            fruit = col.gameObject;
            //And we set us to be able to collect
            collectable = true;            
        }
    }

    //When we exit a trigger
    private void OnTriggerExit(Collider col)
    {
        //We need to establish that we can't collect
        Debug.Log("Trigger Exit");
        collectable = false;
    }
}

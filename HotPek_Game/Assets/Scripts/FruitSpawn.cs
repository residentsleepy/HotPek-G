using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS CODE IS BETTER TO HAVE IN A EMPTY OBJECT

//This code is used to spawn a defined number of fruits in defined locations in a randomized way

public class FruitSpawn : MonoBehaviour
{
    //pointList saves the defined spaces where we would spawn fruits
    //fruits allow us to select the prefabs wi will spawn using the Inspector
    public List<GameObject> pointList = new List<GameObject>();
    public List<GameObject> fruits = new List<GameObject>();
    //With this we define how many we want in the scene
    public int SpawnCount;
    //This is used for the Instantiate function
    private GameObject fruitToSpawn;

    void Start()
    {
        //Since we want our fruits to be available since the beginning of the scene we call the function at Start()
        SpawnFruits();
    }

    //This function is used for the spawning of fruits in the random chosen spaces 
    //making sure we don't put more than 1 in a single place at the time
    void SpawnFruits()
    {
        //We use a cycle that repeats the number of times equal to the fruit we need
        for (int i=0; i<SpawnCount; i++)
        {
            //A Random space and random fruit from our Lists are chosen
            //Let's note that we are using .Count because the number of elements on our list changes during this process
            int choiceSpace = Random.Range(0, pointList.Count);
            int choiceFruit = Random.Range(0, fruits.Count);
            //We Instantiate the chosen fruit in our chosen space
            fruitToSpawn = Instantiate(fruits[choiceFruit], pointList[choiceSpace].transform.position, Quaternion.identity);
            //We delete the space we used from the list to make sure it can only be used one time per game
            pointList.RemoveAt(choiceSpace);
        }
    }
}

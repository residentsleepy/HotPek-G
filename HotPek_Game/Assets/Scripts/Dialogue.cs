using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS CODE BELONGS TO A CHARACTER OR OBJECT THAT NEEDS DIALOGUE


//With the code being serializable we can use it in the Inspector when other code requires it
[System.Serializable]
public class Dialogue
{
    //This can be used for the name of the character or object we interact with and has dialogue
    public string name;
    //This serializable array is used for all the sentences created for the character or object
    [TextArea(3, 10)]
    public string[] sentences;

}
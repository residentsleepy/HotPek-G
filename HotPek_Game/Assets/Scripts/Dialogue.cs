using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ESTE CODIGO VA EN EL OBJETO O PERSONAJE QUE TENGA DIALOGO

[System.Serializable]
public class Dialogue
{
    public string name;

    [TextArea(3, 10)]
    public string[] sentences;

}
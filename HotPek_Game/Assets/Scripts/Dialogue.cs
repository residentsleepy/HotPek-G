using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ESTE CÓDIGO FUNCIONA COMO CLASE, NO NECESITA ESTAR EN OBJETOS O PERSONAJES


//Al ser Serializable damos la oportunidad de cambiar variables cuando usamos esta Clase en otros Scripts
[System.Serializable]
public class Dialogue
{
    public string name; //Representa el nombre con el que el objeto o personaje será identificado en el dialogo
    [TextArea(3, 10)]
    public string[] sentences; //Usamos este arreglo para escribir las oraciones que se usaran como dialogos

}
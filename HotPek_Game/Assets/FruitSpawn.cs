using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ESTE CODIGO PUEDE IR EN UN EMPTY OBJECT

public class FruitSpawn : MonoBehaviour
{
    //Listas que permiten colocar los prefab de las frutas que se usaran y
    //Los puntos en el mapa que se usaran como posición del spawn de las frutas
    public List<GameObject> pointList = new List<GameObject>();
    public List<GameObject> fruits = new List<GameObject>();
    //Cuantas frutas se spawnearan
    public int SpawnCount;
    //Nos sirve como spawner de la fruta y la posición aleatoria
    private GameObject fruitToSpawn;

    void Start()
    {
        //Iniciaremos las escenas spawneando las frutas
        SpawnFruits();
    }

    //Método para hacer el spawn aleatorio de las frutas
    void SpawnFruits()
    {
        //Establecemos un arreglo para guardar las posiciones que se usarán
        Vector3[] positions = new Vector3[SpawnCount];
        //Empecemos un ciclo for que durará según cuantos vamos a spawnear
        for (int i=0; i<SpawnCount; i++)
        {
            //Se elige un número aleatorio entre los posibles de las listas de posiciones y frutas
            int choiceSpace = Random.Range(0, pointList.Count);
            int choiceFruit = Random.Range(0, fruits.Count);
            //La fruta hace spawn, con una fruta aleatoria y la posición de uno de los espacios
            fruitToSpawn = Instantiate(fruits[choiceFruit], pointList[choiceSpace].transform.position, Quaternion.identity);
            //Cuando se usa un espacio, se remueve de la lista para no repetirlo.
            pointList.RemoveAt(choiceSpace);
        }
    }
}

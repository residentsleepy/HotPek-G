using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ESTE CÓDIGO PERTENECE A UN OBJETO VACÍO

//El código nos permite generar frutas entre las opciones de un arreglo y hacerlas aparecer en lugares predefinidos
//Pero de manera aleatoria, asegurandonos que los espacios no se repitan
//De la misma manera podemos definir cuantas frutas queremos que aparezcan

public class FruitSpawn : MonoBehaviour
{
    public List<GameObject> pointList = new List<GameObject>(); //pointList guarda las posiciones que podemos usar para hacer spawn de las frutas
    public List<GameObject> fruits = new List<GameObject>(); //fuits nos permite seleccionar las opciones de frutas que podrían aparecer desde el Inspector
    public int SpawnCount; //Con esto controlamos cuantas frutas queremos que aparezcan en la escena. Consejo: Mantener este número menor a las posiciones disponibles en pointList
    private GameObject fruitToSpawn; //Variable usada para la función de Instancias

    void Start()
    {
        SpawnFruits(); //Como necesitamos las frutas desde el principio de la escena, llamamos al código en Start
    }

    //Esta es la función utilizada para generar las frutas en los espacios definidos 
    //Con esta función tambien nos aseguramos que los espacios sean elegidos aleatoriamente y no se repita la elección
    void SpawnFruits()
    {
        //Con este ciclo nos aseguramos de aparecer la cantidad de frutas que definimos previamente
        for (int i=0; i<SpawnCount; i++)
        {
            int choiceSpace = Random.Range(0, pointList.Count); //Se escoge uno de los espacios disponibles en nuestra lista. Usamos Count porque la lista irá cambiando
            int choiceFruit = Random.Range(0, fruits.Count); //Se escoge alguna de las frutas que tenemos en nuestra lista
            //Se instancía la fruta seleccionada en el espacio seleccionado
            fruitToSpawn = Instantiate(fruits[choiceFruit], pointList[choiceSpace].transform.position, Quaternion.identity);
            fruitToSpawn.tag = "Fruit"; //Le otorgamos el tag Fruit al objeto a hacer spawn para que después pueda ser detectado por el personaje
            fruitToSpawn.transform.localScale *= 2; //Debido al tamaño de los prefab aumentaremos su escala para hacerlos mas visibles en escena
            fruitToSpawn.AddComponent<BoxCollider>(); //Le agregamos un Box Collider
            fruitToSpawn.GetComponent<BoxCollider>().isTrigger = true; //Y hacemos que sea trigger para la interacción con el jugador
            fruitToSpawn.AddComponent<Rigidbody>(); //Agregamos un rigibody que será importante también para la interacción con el jugador
            fruitToSpawn.GetComponent<Rigidbody>().useGravity = false; //Desactivamos la gravedad para evitar que nuestro objeto caiga de su posición original
            pointList.RemoveAt(choiceSpace); //El espacio seleccionado se elimina de nuestra lista para asegurarnos que ninguna otra fruta aparezca en uno usado
        }
    }
}

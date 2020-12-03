using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//ESTE CODIGO PERTENECE AL PERSONAJE PRINCIPAL, ES NECESARIO UN BOX COLLIDER PARA FUNCIONAR

//El código permite al personaje interactuar con objetos como frutas y tambien llevar el conteo de puntuación

public class ColectFruit : MonoBehaviour
{
    int score; //La puntuación del jugador
    public int scoreBonus = 10; //Y el incremento por cada fruta recogida
    private GameObject part, fruit; //Part funciona para el manejo de sistemas de particulas y Fruit representa el objeto a interactuar
    public GameObject particle; //Esto representa el sistema de partículas que usaremos en el juego, puede ser controlado en el Inspector
    public GameObject WinnCanvas;
    private Vector3 fruitPos; //Usado para guardar la ultima posición del objeto que causó un trigger
    private bool collectable = false; //Este booleano es utilizado para determinar si podemos recoger un objeto o no


    void Start()
    {
        score = 0; //Establecemos nuestra puntuación inicial
        Debug.Log("Score: " + score); //Usamos el mensaje en Consola para determinar que la puntuación se registre de manera correcta
    }

    void Update()
    {
        //Si somos capaces de recoger objetos y apretamos Espacio lo siguiente pasa
        if (Input.GetKeyDown(KeyCode.Space) && collectable == true)
        {
            Debug.Log("Space Pressed"); //Un mensaje para comprobar la interacción
            part = Instantiate(particle, fruitPos, Quaternion.identity); //Part toma la instancia del sistema de partículas que tenemos establecido en la posición de la fruta con la que interactuamos
            //Nuestra puntuación sube
            ScoreManager.instence.addScore();
            score = ScoreManager.instence.score;
            Debug.Log("Score: " + score); //Mensaje para comprobar que la puntuación subió
            Destroy(fruit); //Hacemos desaparecer la fruta que recogimos
            collectable = false; //Y establecemos que la interacción acabó haciendo collectable falso
        }

        if(score >= 1)
        {
            WinnCanvas.SetActive(true);
        }
    }

    //Si hacemos trigger con un objeto...
    //(Todo interactuable tiene que tener un trigger collider y rigibody)
    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("Trigger"); //Mensaje de comprobación
        if (col.gameObject.tag == "Fruit") //Si el trigger fue causado por una fruta
        {
            Debug.Log("Trigger with Fruit"); //Mensaje de comprobación

            fruitPos = col.gameObject.transform.position; //Guardamos su posición para usarla después
            //Comprobación rápida de datos
            Debug.Log(col.gameObject.transform.position.x);
            Debug.Log(col.gameObject.transform.position.y);
            Debug.Log(col.gameObject.transform.position.z);
            fruit = col.gameObject; //Establecemos fruit para seguir referenciando al objeto con el que interactuamos
            collectable = true; //Establecemos que es posible recolectar objetos
        }
    }

    //Si salimos del trigger
    private void OnTriggerExit(Collider col)
    {
        Debug.Log("Trigger Exit"); //Mensaje de comprobación
        collectable = false; //Hacemos collectable falso para evitar que podamos recolectar un objeto y destruirlo aunque ya no estemos junto a este
    }
}

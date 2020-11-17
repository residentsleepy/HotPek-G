using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ESTE CODIGO VA EN EL PERSONAJE
//ASEGURAR QUE TENGA EL BOX COLLIDER PARA INTERACTUAR

public class ColectFruit : MonoBehaviour
{
    //Collider que se usa para identificar cuando estamos con un objeto interactuable
    private BoxCollider colli;
    //Puntuación del jugador
    private int score;
    //Part solo sirve para la instancia de las partículas, fruit es para identificar el objeto que será "recogido"
    private GameObject part, fruit;
    //Sistema de partículas, se define en el Inspector
    public GameObject particle;
    //Se guarda la posición de la fruta que causó el ultimo trigger
    private Vector3 fruitPos;
    //Indica si se puede tomar la fruta
    private bool collectable = false;
   
    void Start()
    {
        //Conseguimos el Collider que usaremos para detectar frutas
        colli = GetComponent<BoxCollider>();
        //Establecemos la puntuación inicial
        score = 0;
        Debug.Log("Score: " + score);
    }

    void Update()
    {
        //Si apretamos espacio mientras exista la posibilidad de recoger...
        if (Input.GetKeyDown(KeyCode.Space) && collectable == true)
        {
            Debug.Log("Space Pressed");
            //Se intancia las particulas
            part = Instantiate(particle, fruitPos, Quaternion.identity);
            //La puntuación sube
            score += 10;
            Debug.Log("Score: " + score);
            //La fruta desaparece y volvemos a un estado donde no se puede recoger nada aún
            Destroy(fruit);
            collectable = false;
        }
    }

    //Si hacemos trigger de una colisión...
    //(Las frutas deben tener trigger y Rigibody)
    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("Trigger");
        //Si es fruta...
        if (col.gameObject.tag == "Fruit")
        {
            Debug.Log("Trigger with Fruit");
            //Guardamos su posición
            fruitPos = col.gameObject.transform.position;
            //Comprobación
            Debug.Log(col.gameObject.transform.position.x);
            Debug.Log(col.gameObject.transform.position.y);
            Debug.Log(col.gameObject.transform.position.z);
            //Establecemos la variable para después poder borrar el objeto
            fruit = col.gameObject;
            //Podemos recoger
            collectable = true;            
        }
    }

    //Si salimos de trigger...
    private void OnTriggerExit(Collider col)
    {
        //No podemos recoger
        Debug.Log("Trigger Exit");
        collectable = false;
    }
}

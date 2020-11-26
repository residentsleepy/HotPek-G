using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    //Creamos Variable navMesh
    NavMeshAgent nm;
    //Variable donde indicamos donde esta nuestro jugador
    public Transform target;
    //Distancia de vision 
    public float distanceThreshold = 10f;

    public enum AIState { idle,chasing};
    public AIState aiState = AIState.idle;
    // Start is called before the first frame update
    void Start()
    {
        //Obtenemos el componente NavMesh del Objeto enemigo
        nm = GetComponent<NavMeshAgent>();
        //Empezamos Una Corutina
        StartCoroutine(Think());
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Think()
    {
        while (true)
        {
            //verificamos que hay un objeto conel tag player para seguir, si el enemigo no se mueve.
            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                target = GameObject.FindGameObjectWithTag("Player").transform;
            } else
            {
                target = gameObject.transform;
            }
            switch (aiState)
            {
                case AIState.idle:
                    float dist = Vector3.Distance(target.position, transform.position);
                    if (dist < distanceThreshold)
                    {
                        aiState = AIState.chasing;
                    }
                    nm.SetDestination(transform.position);
                    break;
                case AIState.chasing:
                    dist = Vector3.Distance(target.position, transform.position);
                    if (dist > distanceThreshold)
                    {
                        aiState = AIState.idle;
                    }
                    nm.SetDestination(target.position);
                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(1f);
        }
    }
}

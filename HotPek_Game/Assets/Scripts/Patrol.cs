using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float patrolSpeed = 0f;
    public float changeTargetDistance = 0.1f;
    public Transform[] patrolPoints;
    int currentTarget = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveToTarget())
        {
            //Get Next Target
            GetNextTarget();
        }
    }

    private bool MoveToTarget()
    {
        Vector3 distanceVector = patrolPoints[currentTarget].position - transform.position;
        if(distanceVector.magnitude < changeTargetDistance)
        {
            return true;
        }

        Vector3 velocityVector = distanceVector.normalized;
        transform.position += velocityVector * patrolSpeed * Time.deltaTime;

        return false;
    }

    private int GetNextTarget()
    {
        currentTarget++;
        if(currentTarget >= patrolPoints.Length)
        {
            currentTarget = 0;
        }
        return currentTarget;
    }
}

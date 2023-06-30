using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PatrolState : SeekPlayerState
{
    [SerializeField] private ChaseState chaseState;
    [SerializeField] private Transform centrePoint;
    private int waitTime;
    private float timer;

    private void Awake()
    {
        centrePoint = this.transform;
        waitTime = UnityEngine.Random.Range(2, 5);
    }

    public override State Tick(Enemy zombie)
    {
        timer += Time.deltaTime;
        FindTargetViaLineOfSight(zombie);
        if (zombie.target == null)
        {
            EnemyPatrol(zombie);
            return this;
        }
        else if (zombie.target != null)
        {
            Debug.Log("Player has been found");
            return chaseState;
        }
        else
        {
            return this;
        }
    }

    private void EnemyPatrol(Enemy zombie)
    {
        if (zombie.agent.remainingDistance <= zombie.agent.stoppingDistance) //done with path
        {
            zombie.anim.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);
            Vector3 point;
            if (RandomPoint(centrePoint.position, zombie.patrolSphere, out point)) //pass in our centre point and radius of area
            {
                if (timer >= waitTime) //head to new destination
                {
                    zombie.agent.SetDestination(point);
                    zombie.anim.SetFloat("Vertical", 0.5f);
                    timer = 0;
                }
            }
        }


    }

    private bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + UnityEngine.Random.insideUnitSphere * range; //random point in a sphere 
        UnityEngine.AI.NavMeshHit hit;
        if (UnityEngine.AI.NavMesh.SamplePosition(randomPoint, out hit, 1.0f, UnityEngine.AI.NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }

}


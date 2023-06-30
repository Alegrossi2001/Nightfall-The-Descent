using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekPlayerState : State
{
    //private bool canSeePlayer;
    
    public void FindTargetViaLineOfSight(Enemy zombie)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, zombie.detectionRadius, zombie.detectionLayer);
        foreach (Collider col in colliders)
        {
            Player player = col.transform.GetComponent<Player>();
            if (player != null)
            {
                Vector3 targetDirection = transform.position - player.transform.position;
                float viewableAngle = Vector3.Angle(targetDirection, transform.forward);
                if (viewableAngle > zombie.minDetectionRadiusAngle && viewableAngle < zombie.maxDetectionRadiusAngle)
                {
                    RaycastHit hit;
                    Vector3 playerStartPosition = new Vector3(player.transform.position.x, 1.4f, player.transform.position.z);
                    Vector3 zombieStartPosition = new Vector3(transform.position.x, 1.4f, transform.position.z);
                    if (Physics.Linecast(playerStartPosition, zombieStartPosition, out hit))
                    {
                        Debug.Log(hit.collider);
                        zombie.target = null;
                    }
                    else
                    {
                        zombie.target = player;
                    }
                }
            }
        }
    }

    //private IEnumerator FOVRoutine(Enemy zombie)
    //{
    //    WaitForSeconds wait = new WaitForSeconds(0.2f);

    //    while (true)
    //    {
    //        yield return wait;
    //        FindTargetViaLineOfSight(zombie);
    //    }
    //}

    //public void FindTargetViaLineOfSight(Enemy zombie)
    //{
    //    Collider[] rangeChecks = Physics.OverlapSphere(transform.position, zombie.detectionRadius, zombie.detectionLayer);

    //    if (rangeChecks.Length != 0)
    //    {
    //        Transform target = rangeChecks[0].transform;
    //        Player player = target.GetComponent<Player>();
    //        Vector3 directionToTarget = (target.position - transform.position).normalized;

    //        if (Vector3.Angle(transform.forward, directionToTarget) < zombie.maxDetectionRadiusAngle / 2)
    //        {
    //            float distanceToTarget = Vector3.Distance(transform.position, target.position);

    //            if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, zombie.obstructionMask))
    //            {
    //                Debug.Log("Player has been spotted");
    //                canSeePlayer = true;
    //                zombie.target = player;
    //            }
    //            else
    //            {
    //                canSeePlayer = false;
    //                zombie.target = null;
    //            }
    //        }
    //        else
    //        {
    //            canSeePlayer = false;
    //            zombie.target = null;
    //        }

    //    }
    //    else if (canSeePlayer)
    //    {
    //        canSeePlayer = false;
    //        zombie.target = null;
    //    }

    //}
}

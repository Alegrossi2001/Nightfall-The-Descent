using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : State
{
    [SerializeField] private AttackState attackState;
    [SerializeField] private IdleState idleState;
    public override State Tick(Enemy zombie)
    {
        MoveTowardsTarget(zombie);
        if(Vector3.Distance(zombie.transform.position, zombie.target.transform.position) < zombie.attackDistance)
        {
            return attackState;
        }

        else if(Vector3.Distance(zombie.transform.position, zombie.target.transform.position) > zombie.disengageDistance)
        {
            zombie.target = null;
            return zombie.startingState;
        }
        return this;
    }

    private void MoveTowardsTarget(Enemy zombie)
    {
        zombie.agent.isStopped = false;
        EnemyAnimationManager.instance.ChangeAnimationLayer(-1);
        MusicManager.MusicManagerInstance.PlayMusic(true);
        zombie.anim.SetFloat("Vertical", 1.5f, 0.2f, Time.deltaTime);
        zombie.agent.SetDestination(zombie.target.transform.position);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    [SerializeField] private IdleState idleState;
    [SerializeField] private ChaseState chaseState;
    
    public override State Tick(Enemy zombie)
    {
        if(zombie.DistanceFromTarget() <= zombie.attackDistance)
        {
            EnemyAnimationManager.instance.ChangeAnimationLayer(1);
            return this;
        }
        else if(zombie.DistanceFromTarget() >= zombie.attackDistance)
        {
            EnemyAnimationManager.instance.ChangeAnimationLayer(0);
            return chaseState;
        }
        else if(zombie.DistanceFromTarget() >= zombie.disengageDistance)
        {
            return idleState;
        }
        return this;
    }
}

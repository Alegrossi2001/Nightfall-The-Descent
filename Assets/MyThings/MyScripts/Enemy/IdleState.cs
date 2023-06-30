using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : SeekPlayerState
{
    //make idle until a target has been found
    [SerializeField] private ChaseState chaseTargetState;


    public override State Tick(Enemy zombie)
    {
        if(zombie.target != null)
        {
            return chaseTargetState;
        }
        else
        {
            Debug.Log("Character went idle");
            zombie.agent.isStopped = true;
            MusicManager.MusicManagerInstance.PlayMusic(false);
            zombie.anim.SetFloat("Vertical", 0, 0.2f, Time.deltaTime);
            FindTargetViaLineOfSight(zombie);
            return this;
        }
    }
}

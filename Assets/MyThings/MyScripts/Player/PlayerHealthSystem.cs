using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{
    [SerializeField] private int playerHealth = 100;

    private void Awake()
    {
        HitDetector.onHit += DetectEnemyHit;
    }

    private void DetectEnemyHit()
    {
        TakeDamage(33);
    }
    private void TakeDamage(int health)
    {
        playerHealth -= health;
        if(playerHealth <= 0)
        {
            PlayerDeath();
        }
    }

    private void PlayerDeath()
    {
        //player is dead;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    private bool canDamage;
    private Collider col;
    private Enemy enemy;

    private void Awake()
    {
        col = GetComponent<Collider>();
        enemy = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<Player>())
        {
            HitDetector.EnemyHitPlayer();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetector: MonoBehaviour
{
    public static event Action onHit;
    
    public static void EnemyHitPlayer()
    {
        Debug.Log("Ouch!");
        onHit?.Invoke();
    }
}

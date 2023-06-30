using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIManager : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        HitDetector.onHit += DetectEnemyHit;
        anim = GetComponentInChildren<Animator>();
    }

    private void DetectEnemyHit()
    {
        anim.SetTrigger("Blood");
    }
}

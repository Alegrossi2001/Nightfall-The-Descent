using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationManager : MonoBehaviour
{
    private Animator anim;
    public static EnemyAnimationManager instance { get; private set; }
    private void Awake()
    {
        anim = GetComponent<Animator>();
        instance = this;
    }

    public void PlayAnimation(string animation)
    {
        anim.Play(animation);
    }
    public void ChangeAnimationLayer(int layer)
    {
        anim.SetLayerWeight(1, Mathf.Lerp(anim.GetLayerWeight(1), layer, Time.deltaTime * 13f));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    public virtual State Tick(Enemy zombie)
    {
        return this;
    }
}

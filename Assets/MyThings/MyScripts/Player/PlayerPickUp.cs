using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    private bool hasKey;
    public static PlayerPickUp instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    public void hasPickedUpKey(GameObject key)
    {
        hasKey = true;
        Destroy(key);
    }

    public bool CheckForPlayerKey()
    {
        if (hasKey)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}

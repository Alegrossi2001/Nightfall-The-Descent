using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, IInteractable
{
    public void Interact(Vector3 position)
    {
        PlayerPickUp.instance.hasPickedUpKey(this.gameObject);
    }
}

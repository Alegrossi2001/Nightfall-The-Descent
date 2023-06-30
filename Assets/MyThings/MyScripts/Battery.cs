using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour, IInteractable
{
    public float chargeLevel = 100f;
    public bool isDepleted;

    public void Interact(Vector3 position)
    {
        if (BatteryController.Instance.GetNumberOfBatteries() == false)
        {
            BatteryController.Instance.AddBattery();
            Destroy(this.gameObject);
        }
    }
}

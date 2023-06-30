using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryController : MonoBehaviour
{
    [SerializeField] private int numberOfBatteries;
    [SerializeField] private int maxNumberOfBatteries;
    [SerializeField] private float drainTime;
    private float batteryLevel;
    [SerializeField] private float maxBatteryLevel = 100f;

    //Event onbatterydepletion
    public delegate void OnBatteryDepletion();
    public static  event OnBatteryDepletion batteryDepleted;
    public static BatteryController Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        batteryLevel = maxBatteryLevel;
    }

    public void BatteryDepletion()
    {
        batteryLevel -= drainTime * Time.deltaTime;
        if (batteryLevel <= (maxBatteryLevel * 0.3))
        {
            batteryDepleted();
        }


    }

    public void RechargeBattery()
    {
        if(numberOfBatteries > 0)
        {
            batteryLevel = maxBatteryLevel;
            numberOfBatteries--;
        }

    }

    public void AddBattery()
    {
        numberOfBatteries++;
        if(numberOfBatteries >= maxNumberOfBatteries)
        {
            numberOfBatteries = maxNumberOfBatteries;
        }
    }

    public bool GetNumberOfBatteries()
    {
        //We check if the  number of batteries is greater or equal than the max number of batteries
        return numberOfBatteries >= maxNumberOfBatteries;
    }
}

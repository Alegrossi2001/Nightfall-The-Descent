using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class StaminaController : MonoBehaviour
{
    public float playerStamina = 100f;
    [SerializeField] private float maxStamina = 100f;
    [Range(0f, 100.0f)][SerializeField] private float jumpCost = 20f;
    public bool isSprinting;

    private float staminaDrain = 5f;
    private float staminaRegen = 3f;

    private FirstPersonController playerController;

    private void Awake()
    {
        playerController = GetComponentInParent<FirstPersonController>();
    }

    private void Update()
    {
        if(!isSprinting)
        {
            if(playerStamina <= maxStamina - 0.01f)
            {
                playerStamina += staminaRegen * Time.deltaTime;
            }
        }
    }
    public void Sprinting()
    {
        isSprinting = true;
        playerStamina -= staminaDrain * Time.deltaTime;
    }
    public void StaminaJump()
    {
        if(playerStamina >= maxStamina * (jumpCost / maxStamina))
        {
            playerStamina -= jumpCost;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Headbob : MonoBehaviour
{
    [SerializeField] private float walkingBobbingSpeed = 14f;
    [SerializeField] private float bobbingAmount = 0.05f;
    private FirstPersonController controller;

    private float defaultPosY = 0;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponentInParent<FirstPersonController>();
        defaultPosY = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.GetInput().move != Vector2.zero)
        {
            //Player is moving
            timer += Time.deltaTime * walkingBobbingSpeed;
            transform.localPosition = new Vector3(transform.localPosition.x, defaultPosY + Mathf.Sin(timer) * bobbingAmount, transform.localPosition.z);
        }
        else
        {
            //Idle
            timer = 0;
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(transform.localPosition.y, defaultPosY, Time.deltaTime * walkingBobbingSpeed), transform.localPosition.z);
        }
    }
}

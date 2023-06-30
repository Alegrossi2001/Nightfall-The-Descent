using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TVEffect : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(WaitBeforeSettingObjectInactive(1.0f, 0f));
    }

    private IEnumerator WaitBeforeSettingObjectInactive(float aValue, float t)
    {
        yield return new WaitForSeconds(0.7f);
        this.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        this.gameObject.SetActive(true);
    }
}

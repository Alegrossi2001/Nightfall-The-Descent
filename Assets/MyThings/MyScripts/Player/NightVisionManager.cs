using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class NightVisionManager : MonoBehaviour
{
    [SerializeField] private PostProcessVolume volume;
    [SerializeField] private PostProcessProfile standardVision;
    [SerializeField] private PostProcessProfile nightVision;
    //private RawImage tvStaticEffect;
    private bool isNightVisionOff;
    [SerializeField] private GameObject nightVisionCanvas;

    private void Awake()
    {
        nightVisionCanvas.SetActive(false);
    }

    public IEnumerator ToggleNightVisionOn(bool nightVision)
    {
        yield return new WaitForSeconds(0.3f);
        ToggleNightVision(nightVision);
    }

    private void ToggleNightVision(bool nightVisionOn)
    {
        if (nightVisionOn)
        {
            volume.profile = nightVision;
            isNightVisionOff = false;
            nightVisionCanvas.SetActive(true);
        }
        else
        {
            volume.profile = standardVision;
            isNightVisionOff = true;
            nightVisionCanvas.SetActive(false);
        }
    }

    public bool IsNightVisionOff()
    {
        return isNightVisionOff;
    }
}

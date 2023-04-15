using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PV_CityMap : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    public void MakeVisible() => canvasGroup.alpha = 1;
    public void MakeInvisible() => canvasGroup.alpha = 0;

    public void EnableInteractable()
    {
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }
    public void DisableInteractable()
    {
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
}

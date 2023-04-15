using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PV_CityMap : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    public void EnableInteractable() => canvasGroup.interactable = true;
    public void DisableInteractable() => canvasGroup.interactable = false;
}

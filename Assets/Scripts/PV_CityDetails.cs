using UnityEngine;

public class PV_CityDetails : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    public PV_CityDetailsNormal normalDetails;
    public PV_CityDetailsEvent eventDetails;

    public void ShowNormalDetails()
    {
        normalDetails.gameObject.SetActive(true);
        eventDetails.gameObject.SetActive(false);
    }
    public void ShowEventDetails()
    {
        normalDetails.gameObject.SetActive(false);
        eventDetails.gameObject.SetActive(true);
    }

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

using UnityEngine;

public class PV_CityDetails : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public SpriteRenderer spRender;

    [Range(1,10)]
    public int pointsConstruction = 1;
    [Range(1, 10)]
    public int pointsSocial = 1;
    [Range(1, 10)]
    public int pointsEnviromental = 1;
    [Range(1, 10)]
    public int pointsProduction = 1;

    [Space(10)]
    public PV_CityDetailsArea areaConstruction;
    public PV_CityDetailsArea areaSocial;
    public PV_CityDetailsArea areaEnviromental;
    public PV_CityDetailsArea areaProduction;

    public void ShowCityUpgradeOptions()
    {
        areaConstruction.SetAreaState(pointsConstruction);
        areaSocial.SetAreaState(pointsSocial);
        areaEnviromental.SetAreaState(pointsEnviromental);
        areaProduction.SetAreaState(pointsProduction);
    }
    public void EnableInteractable() => canvasGroup.interactable = true;
    public void DisableInteractable() => canvasGroup.interactable = false;
}

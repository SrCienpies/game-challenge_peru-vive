using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PV_CityDetailsNormal : MonoBehaviour
{
    public Image background;
    public Text cityName;

    [Range(1, 10)]
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

    [Header("Options")]
    public Image opaque;


    public void ShowCityUpgradeOptions(SNormal data)
    {
        background.sprite = data.cityBackground;
        cityName.text = data.cityName;

        areaConstruction.SetAreaState(pointsConstruction);
        areaSocial.SetAreaState(pointsSocial);
        areaEnviromental.SetAreaState(pointsEnviromental);
        areaProduction.SetAreaState(pointsProduction);
    }

    public void ShowOptions(List<Initiative> initiatives)
    {

    }


}

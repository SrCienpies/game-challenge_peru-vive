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
    public PV_CityOptionsScreen initiativesScreen;


    public void ShowCityUpgradeOptions(SNormal data)
    {
        background.sprite = data.cityBackground;
        cityName.text = data.cityName;

        areaConstruction.SetAreaState(pointsConstruction);
        areaSocial.SetAreaState(pointsSocial);
        areaEnviromental.SetAreaState(pointsEnviromental);
        areaProduction.SetAreaState(pointsProduction);

        areaConstruction.OnClick = () => ShowOptions(data.planificaicon, Area.Areaname.Planificacion, pointsConstruction);
        areaSocial.OnClick = () => ShowOptions(data.social, Area.Areaname.Social, pointsSocial);
        areaEnviromental.OnClick = () => ShowOptions(data.medioAmbiente, Area.Areaname.MedioAmbiente, pointsEnviromental);
        areaProduction.OnClick = () => ShowOptions(data.economia, Area.Areaname.Economia, pointsProduction);

        initiativesScreen.gameObject.SetActive(false);
    }

    public void ShowOptions(List<Initiative> initiatives, Area.Areaname areaName, int state)
    {
        initiativesScreen.gameObject.SetActive(true);
        initiativesScreen.SetOptionsData(initiatives, areaName, state);
    }


}

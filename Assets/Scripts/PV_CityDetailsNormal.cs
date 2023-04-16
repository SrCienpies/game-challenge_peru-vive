using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PV_CityDetailsNormal : MonoBehaviour
{
    public PV_CityDetails controller;

    public Image background;
    public Image transition;
    public Text cityName;

    [Header("General State")]
    public Image stateBackground;
    public Text state;

    public Color colorGreen;
    public Color colorYellow;
    public Color colorRed;

    [Range(1, 20)]
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
        GetComponent<CanvasGroup>().interactable = true;

        SetGeneralState();

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
    public void SetGeneralState()
    {
        int generalState = (pointsConstruction + pointsSocial + pointsEnviromental + pointsProduction) / 4;

        if (generalState <= 3)
        {
            stateBackground.color = colorGreen;
        }
        else if (generalState <= 6)
        {
            stateBackground.color = colorYellow;
        }
        else
        {
            stateBackground.color = colorRed;
        }

        this.state.text = generalState.ToString();
    }

    public void ShowOptions(List<Initiative> initiatives, Area.Areaname areaName, int state)
    {
        initiativesScreen.cityDetailsNormal = this;
        initiativesScreen.gameObject.SetActive(true);
        initiativesScreen.SetOptionsData(initiatives, areaName, state);
    }
    public void UpdateState(int areaState, Area.Areaname areaName)
    {
        switch (areaName)
        {
            case Area.Areaname.Planificacion:
                pointsConstruction = areaState;
                areaConstruction.SetAreaState(pointsConstruction);
                break;
            case Area.Areaname.Social:
                pointsSocial = areaState;
                areaSocial.SetAreaState(pointsSocial);
                break;
            case Area.Areaname.MedioAmbiente:
                pointsEnviromental = areaState;
                areaEnviromental.SetAreaState(pointsEnviromental);
                break;
            case Area.Areaname.Economia:
                pointsProduction = areaState;
                areaProduction.SetAreaState(pointsProduction);
                break;
        }

        SetGeneralState();
        initiativesScreen.gameObject.SetActive(false);

        GetComponent<CanvasGroup>().interactable = false;

        Invoke("UpgradeCompleted", 1);
    }
    public async void UpgradeCompleted()
    {
        
    }


}

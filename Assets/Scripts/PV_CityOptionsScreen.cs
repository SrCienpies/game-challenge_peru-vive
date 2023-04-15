using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PV_CityOptionsScreen : MonoBehaviour
{
    public Image background;

    [Header("Area")]
    public Image areaIcon;
    public Text areaTitle;
    public Image areaLevelBackground;
    public Text areaLevel;

    [Header("Character")]
    public Image character;
    public Image characterBackground;
    public Text characterName;
    public Text characterMessage;
    public Image characterMessageColor;

    [Header("Options")]
    public PV_InitiativeOption[] options;

    public void SetOptionsData(Initiative data, Area.Areaname areaName)
    {

    }
}

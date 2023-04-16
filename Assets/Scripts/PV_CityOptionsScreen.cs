using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PV_CityOptionsScreen : MonoBehaviour
{
    public Image background;

    [Header("Characters")]
    public SO_Characters chPlanificacion;
    public SO_Characters chSocial;
    public SO_Characters chMedioAmbeinte;
    public SO_Characters chEconomia;

    [Header("Area")]
    public Image areaIcon;
    public Text areaTitle;
    public Image areaLevelBackground;
    public Text areaLevel;

    [Header("Colors")]
    public Color colorGreen;
    public Color colorYellow;
    public Color colorRed;

    [Header("Character")]
    public Image character;
    public Image characterBackground;
    public Text characterName;
    public Text characterMessage;
    public Image characterMessageColor;

    [Header("Options")]
    public PV_InitiativeOption[] options;

    public void SetOptionsData(List<Initiative> initiatives, Area.Areaname areaName, int state)
    {
        areaLevel.text = state.ToString();

        if(state <= 3)
        {
            areaLevelBackground.color = colorGreen;
        }
        else if (state <= 6)
        {
            areaLevelBackground.color = colorYellow;
        }
        else
        {
            areaLevelBackground.color = colorRed;
        }

        for (int i = 0; i < options.Length; i++)
        {
            Initiative initiative = initiatives[i];
            options[i].SetOptionData(initiative, areaName);
        }

        SO_Characters currentCharacter = chPlanificacion;

        switch (areaName)
        {
            case Area.Areaname.Planificacion:
                currentCharacter = chPlanificacion;
                break;
            case Area.Areaname.Social:
                currentCharacter = chSocial;
                break;
            case Area.Areaname.MedioAmbiente:
                currentCharacter = chMedioAmbeinte;
                break;
            case Area.Areaname.Economia:
                currentCharacter = chEconomia;
                break;
            default:
                break;
        }

        character.sprite = currentCharacter.character;
        characterBackground.color = currentCharacter.color;
        characterName.text = currentCharacter.characterName;
        characterMessage.text = currentCharacter.characterMessage;
        characterMessageColor.sprite = currentCharacter.characterDialog;
    }
}
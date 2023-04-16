using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PV_CityOptionsScreen : MonoBehaviour
{
    public PV_CityDetailsNormal cityDetailsNormal;
    public Image background;

    [Header("Characters")]
    public SO_Characters chPlanificacion;
    public SO_Characters chSocial;
    public SO_Characters chMedioAmbeinte;
    public SO_Characters chEconomia;

    [Header("Themes")]
    public Sprite iconPlanification;
    public Sprite iconSocial;
    public Sprite iconMedioAmbeinte;
    public Sprite iconEconomia;

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


    private int currentState;

    public void SetOptionsData(List<Initiative> initiatives, Area.Areaname areaName, int state)
    {
        currentState = state;

        SetAreaLevel(state);

        for (int i = 0; i < options.Length; i++)
        {
            Initiative initiative = initiatives[i];
            PV_InitiativeOption option = options[i];

            option.SetOptionData(initiative, areaName);
            option.OnClick = ()=> UpdateState(initiative, areaName);
        }

        SetCharacter(areaName);
        SetAreaIcon(areaName);
    }
    private void SetCharacter(Area.Areaname areaName)
    {
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
    private void SetAreaIcon(Area.Areaname areaName)
    {
        switch (areaName)
        {
            case Area.Areaname.Planificacion:
                areaIcon.sprite = iconPlanification;
                areaTitle.text = "Planificación";
                break;
            case Area.Areaname.Social:
                areaIcon.sprite = iconSocial;
                areaTitle.text = "Social";
                break;
            case Area.Areaname.MedioAmbiente:
                areaIcon.sprite = iconMedioAmbeinte;
                areaTitle.text = "Medio Ambiente";
                break;
            case Area.Areaname.Economia:
                areaIcon.sprite = iconEconomia;
                areaTitle.text = "Economia";
                break;
        }

    }
    private void SetAreaLevel(int state)
    {
        areaLevel.text = state.ToString();

        if (state <= 3)
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
    }
    private void UpdateState(Initiative initiative, Area.Areaname areaName)
    {
        int points = 0;

        switch (initiative.levelnum)
        {
            case Initiative.level.A:
                points = 0;
                break;
            case Initiative.level.B:
                points = 1;
                break;
            case Initiative.level.C:
                points = 2;
                break;
        }

        currentState -= points;

        if (currentState <= 1) currentState = 1;

        cityDetailsNormal.UpdateState(currentState, areaName);
    }
}
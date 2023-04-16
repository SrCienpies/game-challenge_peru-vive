using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PV_InitiativeOption : MonoBehaviour
{
    public Image background;
    public Text title;
    public Text description;
    public Button button;

    [Header("Colors")]
    public Sprite colorPlanificacion;
    public Sprite colorSocial;
    public Sprite colorMedioAmbiente;
    public Sprite colorEconomia;

    public delegate void Click();
    public Click OnClick;

    private void Awake()
    {
        button.onClick.AddListener(() => OnClick?.Invoke());
    }
    public void SetOptionData(Initiative data, Area.Areaname areaName)
    {
        switch (areaName)
        {
            case Area.Areaname.Planificacion:
                background.sprite = colorPlanificacion;
                break;
            case Area.Areaname.Social:
                background.sprite = colorSocial;
                break;
            case Area.Areaname.MedioAmbiente:
                background.sprite = colorMedioAmbiente;
                break;
            case Area.Areaname.Economia:
                background.sprite = colorEconomia;
                break;
            default:
                background.sprite = colorPlanificacion;
                break;
        }

        title.text = data.Nombre;
        description.text = data.Desc;
    }
}

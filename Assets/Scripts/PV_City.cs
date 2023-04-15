using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class PV_City : MonoBehaviour
{
    [Space(10)]
    [Header("Initial State")]
    [Range(1,10)]
    public int initialState = 1;

    [Space(10)]
    public Sprite iconStateGreen;
    public Sprite iconStateYellow;
    public Sprite iconStateRed;

    [Space(10)]
    public Image fill;
    public Image icon;
    public Text stateLevel;
    public Button button;

    private IEnumerator routineStartEvent;
    private int cityState;
    

    private void Start()
    {
        cityState = initialState;
        fill.fillAmount = 0;

        SetCityState(initialState);
    }

    public void SetCityState(int stateLevel)
    {
        this.stateLevel.text = stateLevel.ToString();

        if (stateLevel <= 3)
        {
            icon.sprite = iconStateGreen;
            return;
        }

        if (stateLevel <= 6)
        {
            icon.sprite = iconStateYellow;
            return;
        }

        icon.sprite = iconStateRed;
    }
    public void StartEvent()
    {
        routineStartEvent = RoutineStartEvent();
        StartCoroutine(routineStartEvent);
    }
    public void StopEvent()
    {
        fill.DOKill();
        StopCoroutine(routineStartEvent);
    }

    IEnumerator RoutineStartEvent()
    {
        while (true)
        {
            yield return fill.DOFillAmount(1, 3).WaitForCompletion();

            cityState++;
            fill.fillAmount = 0;
            SetCityState(cityState); fill.fillAmount = 0;

            if(cityState >= 10)
            {
                GameEvents.GameFault();
                yield break;
            }

            yield return null; 
        }
    }

    public void ShowEventOptions(PV_GameplayScreen controller)
    {
        if (controller.onEvent)
        {
            if (cityState <= 3)
            {
                controller.FindAnotherCity();
            }
            else
            {
                controller.ShowCityEventOptions();
            }

            return;
        }

        controller.ShowCityUpgradeOptions();
    }
}

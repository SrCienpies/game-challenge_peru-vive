using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PV_GameplayScreen : MonoBehaviour
{
    public PV_City[] cities;

    [Header("Calendar")]
    public float daysPerMonth;
    public float passDayRate;
    public PV_CalendarPage[] calendarPages;

    [Header("City")]
    public PV_CityDetails cityDetails;
    public PV_CityMap cityMap;

    [Header("Transition")]
    public Image transition;

    [Header("Disaster Event")]
    public int disasterDurationDays = 10;

    public bool onEvent;
    public bool pauseDays;

    private int currentMonth = 1;

    private void Awake()
    {
        GameEvents.onGameFault += OnGameFault;
    }

    private void Start()
    {
        cityMap.gameObject.SetActive(true);
        cityDetails.gameObject.SetActive(false);

        StartCoroutine("PassTheDays");
    }

    private IEnumerator PassTheDays()
    {
        int currentDay = 1;

        calendarPages[0].SetDay(currentDay);
        calendarPages[1].SetDay(currentDay + 1);

        while (true)
        {
            while (pauseDays)
            {
                yield return null;
            }

            yield return new WaitForSeconds(passDayRate);

            calendarPages[1].MakeVisible();
            calendarPages[1].RestartPosition();
            calendarPages[1].transform.SetAsFirstSibling();
            calendarPages[1].SetDay(currentDay + 1);

            yield return new WaitForSeconds(1f);

            calendarPages[0].DropPage();

            PV_CalendarPage auxPage = calendarPages[0];

            calendarPages[0] = calendarPages[1];
            calendarPages[1] = auxPage;
            currentDay++;

            if (MonthIsCompleted(currentDay))
            {
                currentMonth++;
                currentDay = 0;
                CheckIfEventHappens();
            }

        }

    }
    private IEnumerator DisasterEvent()
    {
        float currentDay = 0;

        StartEventOnCities();

        while (currentDay < disasterDurationDays)
        {
            yield return new WaitForSeconds(passDayRate);
            currentDay++;
        }

        StopEventOnCities();
    }
    private bool MonthIsCompleted(int currentDay)
    {
        return currentDay >= daysPerMonth;
    }
    private void CheckIfEventHappens()
    {
        if(currentMonth == 2)
        {
            Debug.Log("Ocurre un evento especial");
            StartCoroutine(DisasterEvent());
        }
    }
    private void StartEventOnCities()
    {
        foreach (PV_City city in cities)
        {
            city.StartEvent();
        }
    }
    private void StopEventOnCities()
    {
        foreach (PV_City city in cities)
        {
            city.StopEvent();
        }
    }

    #region City Events

    public void FindAnotherCity()
    {

    }
    public void ShowCityEventOptions()
    {

    }
    public async void ShowCityUpgradeOptions()
    {
        pauseDays = true;
        cityMap.DisableInteractable();
        await TransitionIn().AsyncWaitForCompletion();

        cityMap.gameObject.SetActive(false);
        cityDetails.gameObject.SetActive(true);
        cityDetails.DisableInteractable();

        await TransitionOut().AsyncWaitForCompletion();

        cityDetails.EnableInteractable();
        cityDetails.ShowCityUpgradeOptions();
    }

    #endregion

    #region Transitions
    private Tween TransitionIn()
    {
        transition.gameObject.SetActive(true);
        return transition.DOFade(1, 0.25f).From(0);
    }
    private Tween TransitionOut()
    {
        transition.gameObject.SetActive(true);
        return transition.DOFade(0, 0.25f)
            .From(1)
            .OnComplete(() => transition.gameObject.SetActive(false));
    }

    #endregion

    private void OnGameFault()
    {
        StopEventOnCities();
        StopCoroutine("PassTheDays");

        Debug.Log("Perdiste el juego");
    }
    private void OnDestroy()
    {
        GameEvents.onGameFault -= OnGameFault;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PV_GameplayScreen : MonoBehaviour
{
    public PV_City[] cities;

    [Header("Calendar")]
    public float daysPerMonth;
    public float passDayRate;
    public PV_CalendarPage[] calendarPages;

    [Header("Disaster Event")]
    public int disasterDurationDays = 10;



    private int currentMonth = 1;

    private void Start()
    {
        StartCoroutine(PassTheDays());
    }

    private IEnumerator PassTheDays()
    {
        int currentDay = 1;

        calendarPages[0].SetDay(currentDay);
        calendarPages[1].SetDay(currentDay + 1);

        while (true)
        {
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

        while(currentDay < disasterDurationDays)
        {
            yield return new WaitForSeconds(passDayRate);
            currentDay++;
        }

        Debug.Log("Termino el evento");
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
}

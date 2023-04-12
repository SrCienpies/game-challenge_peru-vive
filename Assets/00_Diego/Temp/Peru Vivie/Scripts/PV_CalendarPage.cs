using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PV_CalendarPage : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public Text day;

    private Vector2 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    public void SetDay(int currentDay)
    {
        day.text = currentDay.ToString();
    }
    public void RestartPosition() => transform.position = initialPosition;
    public void MakeVisible()=> canvasGroup.alpha = 1;
    public void DropPage()
    {
        float initialYPosition = transform.position.y;
        float finalYPosition = initialYPosition - 3;

        canvasGroup.DOFade(0, 1).From(1);
        canvasGroup.transform.DOMoveY(finalYPosition, 1).From(initialYPosition);
    }
}

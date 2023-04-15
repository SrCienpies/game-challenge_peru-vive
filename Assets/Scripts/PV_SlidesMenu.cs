using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PV_SlidesMenu : MonoBehaviour
{
    public GameObject[] slides;
    public Button buttonNext;
    public Button buttonPrev;

    [SerializeField]
    private int currentSlide;

    public delegate void SlidesReachEnd();
    public SlidesReachEnd OnSlidesReachEnd;

    private void Awake()
    {
        Initialize();

        buttonPrev.onClick.AddListener(ShowPrevSlide);
        buttonNext.onClick.AddListener(ShowNextSlide);
    }

    public void Initialize()
    {
        currentSlide = 0;

        foreach (GameObject slide in slides)
        {
            slide.SetActive(false);
        }

        slides[currentSlide].SetActive(true);

        buttonPrev.gameObject.SetActive(false);
        buttonNext.onClick.RemoveAllListeners();
        buttonNext.onClick.AddListener(ShowNextSlide);
    }

    public void ShowNextSlide()
    {
        slides[currentSlide].SetActive(false);
        slides[currentSlide+1].SetActive(true);

        currentSlide++;

        buttonNext.onClick.RemoveAllListeners();

        if (currentSlide >= slides.Length - 1)
        {
            buttonNext.onClick.AddListener(OnSlidesReachEnd.Invoke);
        }
        else
        {
            buttonNext.onClick.AddListener(ShowNextSlide);
        }

        CheckPreviousButtonState();
    }
    public void ShowPrevSlide()
    {
        slides[currentSlide].SetActive(false);
        slides[currentSlide - 1].SetActive(true);
        currentSlide--;
        CheckPreviousButtonState();
    }

    private void CheckPreviousButtonState()
    {
        buttonPrev.gameObject.SetActive(currentSlide != 0);
    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Collections;

public class PV_MenuScreen : MonoBehaviour
{
    public string gameplayScene;

    [Space(10)]
    public GameObject mainMenu;
    public GameObject creditsMenu;
    public GameObject slidesMenu;

    [Space(10)]
    public CanvasGroup cvGroup;
    public Image transition;
    public PV_SlidesMenu slides;

    private void Awake()
    {
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
        slidesMenu.SetActive(false);

        slides.OnSlidesReachEnd = () => StartCoroutine(StartGame());
    }
    private IEnumerator StartGame()
    {
        cvGroup.interactable = false;
        yield return TransitionIn().WaitForCompletion();
        SceneManager.LoadScene(gameplayScene);
    }

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
            .OnComplete(()=> transition.gameObject.SetActive(false));
    }

    public void ShowMainMenu() => StartCoroutine(RoutineShowMainMenu());
    public void ShowCreditsMenu() => StartCoroutine(RoutineShowCreditsScreen());
    public void ShowSlidesMenu() => StartCoroutine(RoutineShowSlidesMenu());

    IEnumerator RoutineShowMainMenu()
    {
        cvGroup.interactable = false;
        yield return TransitionIn().WaitForCompletion();

        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
        slidesMenu.SetActive(false);

        yield return TransitionOut().WaitForCompletion();
        cvGroup.interactable = true;
    }
    IEnumerator RoutineShowCreditsScreen()
    {
        cvGroup.interactable = false;
        yield return TransitionIn().WaitForCompletion();

        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
        slidesMenu.SetActive(false);

        yield return TransitionOut().WaitForCompletion();
        cvGroup.interactable = true;
    }
    IEnumerator RoutineShowSlidesMenu()
    {
        cvGroup.interactable = false;
        yield return TransitionIn().WaitForCompletion();

        mainMenu.SetActive(false);
        creditsMenu.SetActive(false);
        slidesMenu.SetActive(true);

        slides.Initialize();

        yield return TransitionOut().WaitForCompletion();
        cvGroup.interactable = true;
    }
}

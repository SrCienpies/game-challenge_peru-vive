using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System.Collections;

public class PV_MenuScreen : MonoBehaviour
{
    public string gameplayScene;

    [Space(10)]
    public CanvasGroup cvGroup;
    public Button buttonStart;
    public Image transition;

    private void Awake()
    {
        buttonStart.onClick.AddListener(()=> StartCoroutine(StartGame()));
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
        return transition.DOFade(0, 0.25f).From(1);
    }
}

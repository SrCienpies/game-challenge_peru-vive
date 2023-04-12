using UnityEngine;
using UnityEngine.UI;


public class PV_City : MonoBehaviour
{
    [Space(10)]
    [Header("Initial State")]
    [Range(1,10)]
    public int initialState = 1;

    [Space(10)]
    public Color statesGood;
    public Color statesMedium;
    public Color statesBad;
    public Color statesFatal;

    [Space(10)]
    public SpriteRenderer spriteRender;
    public Text stateLevel;

    private void Start()
    {
        SetCityState(initialState);
    }

    public void SetCityState(int stateLevel)
    {
        this.stateLevel.text = stateLevel.ToString();

        if (stateLevel <= 3)
        {
            spriteRender.color = statesGood;
            return;
        }

        if (stateLevel <= 6)
        {
            spriteRender.color = statesMedium;
            return;
        }

        if (stateLevel <= 0)
        {
            spriteRender.color = statesBad;
            return;
        }

        spriteRender.color = statesFatal;
    }
}

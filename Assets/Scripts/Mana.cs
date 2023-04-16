using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{
    public int max;
    public float rate;
    public Image fill;
    public Text amount;

    public int currentAmount = 0;
    private bool increaseMana;

    private void Awake()
    {
        fill.fillAmount = 1;
        currentAmount = max;

        amount.text = $"{currentAmount}/{max}";
    }

    private void Update()
    {
        if (increaseMana)
        {
            fill.fillAmount += Time.deltaTime * rate;
        }

        if(fill.fillAmount >= 1)
        {
            currentAmount++;

            if (currentAmount >= max)
            {
                currentAmount = max;
            }
            else
            {
                fill.fillAmount = 0;
            }

            amount.text = $"{currentAmount}/{max}";
        }

        increaseMana = (currentAmount < max);
    }
}

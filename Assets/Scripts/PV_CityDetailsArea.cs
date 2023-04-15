using UnityEngine;
using UnityEngine.UI;


public class PV_CityDetailsArea : MonoBehaviour
{
    public Color colorGreen;
    public Color colorYellow;
    public Color colorRed;

    public Image statusColor;
    public Text statusIndicator;

    public void SetAreaState(int state)
    {
        statusIndicator.text = state.ToString();

        if (state <= 3)
        {
            statusColor.color = colorGreen;
            return;
        }

        if (state <= 6)
        {
            statusColor.color = colorYellow;
            return;
        }

        statusColor.color = colorRed;
    }
}

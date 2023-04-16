using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ini_main : MonoBehaviour
{
    public Main_Data main;
    public GameObject allobj;

    public Image main_img;
    public TextMeshProUGUI nom_main;
    public TextMeshProUGUI num_main;
    public Image num_col;
    public List<TextMeshProUGUI> area_main = new List<TextMeshProUGUI>();
    public List<Image> area_col = new List<Image>();
    public Ini_obj_main ini_obj;
    public Lugar_main main_lugar;

    public void sendinfo(Lugar_main obj)
    {
        main_lugar = obj;

        main_img.sprite = obj.main_img;
        nom_main.text = obj.nombre;
        

        for (int i = 0; i < 4; i++)
        {
            area_main[i].text = obj.area[i].area_num.ToString();
            area_col[i].color = main.main.calc_ico_col(obj.area[i].area_num).col_main;
        }

        num_main.text = obj.main_num.ToString();
        num_col.color = main.main.calc_ico_col(obj.main_num).col_main;
    }




    public void open_init(int go)
    {
        main_lugar.return_init(go);
        ini_obj.def_area(go);
    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main_Data:MonoBehaviour
{
    public main_data_info main;
    public Ini_main inic_main;
    public Lugar_mng lug_actual;
    public Actual_situation act_actual;
    public Choice_main choice_main;
    public List<Area_points> area_point_obj = new List<Area_points>();

    public List<Lugar_mng> lugares_obj = new List<Lugar_mng>();

    private void Start()
    {
        inic_main.allobj.SetActive(false);
        inic_main.ini_obj.all.SetActive(false);
        choice_main.all.SetActive(false);
    }

    public void sendinfo(GameObject obj)
    {
        Lugar_main lug;
        lug = obj.GetComponent<Lugar_mng>().lug;
        lug_actual = obj.GetComponent<Lugar_mng>();

        switch (act_actual.estado_actual)
        {
            case 0:
                inic_main.allobj.SetActive(true);
                inic_main.sendinfo(lug);
                break;

            case 1:
                choice_main.lug = lug;
                choice_main.select_lug();
                break;
        }


    }

    public void closeini()
    {
        inic_main.allobj.SetActive(false);

    }





    public void check_puntos()
    {
        if(area_point_obj[0].puntos== 0 && area_point_obj[1].puntos == 0 && area_point_obj[2].puntos == 0 && area_point_obj[3].puntos == 0)
        {
            act_actual.id_num++;
            act_actual.change();
        }
    }

    public void check_lugares()
    {
        lugares_obj.Clear();
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");

        for (int i = 0; i < objs.Length; i++)
        {
            Lugar_mng mng_obj;
            mng_obj = objs[i].GetComponent<Lugar_mng>();

            if(mng_obj.lug.main_num>3)
            {
                lugares_obj.Add(mng_obj);
            }
        }


    }


}

[System.Serializable]
public class main_data_info
{
    public List<Color> colores_main = new List<Color>();
    public List<Sprite> iconos_main = new List<Sprite>();

    public List<SO_Characters2> characters_area = new List<SO_Characters2>();


    public main_data_obj calc_ico_col(int num)
    {
        main_data_obj obj1 = new main_data_obj();


        switch (num)
        {
            case 1:
                obj1.col_main = colores_main[0];
                obj1.ico_main = iconos_main[0];
                break;
            case 2:
                obj1.col_main = colores_main[0];
                obj1.ico_main = iconos_main[0];
                break;
            case 3:
                obj1.col_main = colores_main[0];
                obj1.ico_main = iconos_main[0];
                break;
            case 4:
                obj1.col_main = colores_main[1];
                obj1.ico_main = iconos_main[1];
                break;
            case 5:
                obj1.col_main = colores_main[1];
                obj1.ico_main = iconos_main[1];
                break;
            case 6:
                obj1.col_main = colores_main[1];
                obj1.ico_main = iconos_main[1];
                break;
            case 7:
                obj1.col_main = colores_main[2];
                obj1.ico_main = iconos_main[2];
                break;
            case 8:
                obj1.col_main = colores_main[2];
                obj1.ico_main = iconos_main[2];
                break;
            case 9:
                obj1.col_main = colores_main[2];
                obj1.ico_main = iconos_main[2];
                break;
            case 10:
                obj1.col_main = colores_main[2];
                obj1.ico_main = iconos_main[2];
                break;       
        }

        return obj1;
    }

}

[System.Serializable]
public class main_data_obj
{
    public Sprite ico_main;
    public Color col_main;
}

[System.Serializable]
public class SO_Characters2
{
    public string area;
    public Sprite character;
    public Color color;
    public Sprite icon;
    public string characterName;
    public string characterMessage;
    public Sprite characterDialog;
    public Sprite change_but;
}

[System.Serializable]
public class Area_points
{
    public string area;
    public int puntos;
}
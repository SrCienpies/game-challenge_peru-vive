using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Lugar_main 
{
    public string nombre;
    public int main_num;
    public List<Area_info> area = new List<Area_info>();
    public Sprite main_img;
    public List<Init_Area> inits_obj = new List<Init_Area>();
    public Actual_situation actual_sit_obj;

    public initiative ini1;
    public initiative ini2;
    public initiative ini3;

    public void calculate_num()
    {
        int prom = area[0].area_num + area[1].area_num +area[2].area_num + area[3].area_num;
        main_num = prom / 4;
    }

    public void calculate_area(int area_num, int num)
    {
        area[area_num].area_num = area[area_num].area_num + num;
    }

    public void return_init(int area_num)
    {
        ini1 = inits_obj[area_num].inits_obj1[actual_sit_obj.id_num].init[0];
        ini2 = inits_obj[area_num].inits_obj1[actual_sit_obj.id_num].init[1];
        ini3 = inits_obj[area_num].inits_obj1[actual_sit_obj.id_num].init[2];
        
    }

}

[System.Serializable]
public class Init_Area
{
    public string area_nom;
    public List<SO_Initiatives2> inits_obj1 = new List<SO_Initiatives2>();

}

[System.Serializable]
public class Area_info
{
    public string nom;
    public int area_num;
}

[System.Serializable]
public class initiative
{
    public string ini_nom;
    [TextArea]
    public string ini_desc;
    public int num;
}


[System.Serializable]
public class choice
{
    public string choice_name;
    public string choice_desc;
    public bool choice_aceptar_true;
}

[System.Serializable]

public class SO_Initiatives2
{
    public List<initiative> init = new List<initiative>();
    public List<choice> choice_obj = new List<choice>();
}
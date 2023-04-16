using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actual_situation : MonoBehaviour
{
    public int id_num;
    public int estado_actual;
    public Main_Data main;
    public int cantidad_puntos;
    public Choice_main choice_main;

    public void change()
    {

    }

    public void Start()
    {
        restart_points();
    }

    public void restart_points()
    {
        List<Area_points> list_f;
        list_f = main.area_point_obj;

        for (int i = 0; i < list_f.Count; i++)
        {
            list_f[i].puntos = cantidad_puntos;
        }
    }

    


    // 0 - 1 - 2 - 0 - 2 - 0 - 0



}

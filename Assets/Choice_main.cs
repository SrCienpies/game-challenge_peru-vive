using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Choice_main : MonoBehaviour
{
    public GameObject all;
    public Image lugar_img;
    public TextMeshProUGUI lugar_nom;
    public TextMeshProUGUI lugar_cant;
    public TextMeshProUGUI lugar_pos;

    public TextMeshProUGUI choice_nom;
    public TextMeshProUGUI choice_desc;

    public Main_Data main;
    public Actual_situation actual;
    public Lugar_main lug;
    public List<choice> list_choice = new List<choice>();
    public int id_actual;

    public void def(choice item1)
    {
        choice_nom.text = item1.choice_name;
        choice_desc.text = item1.choice_desc;

        int num_check;
        num_check = id_actual + 1;

        lugar_pos.text = num_check + "/3";

        lugar_img.color = main.main.calc_ico_col(lug.main_num).col_main;
        lugar_nom.text = lug.nombre;
        lugar_cant.text = lug.main_num.ToString();

    }

    public void calculate_main()
    {
        main.lug_actual.set_col_img();
        lugar_img.color = main.main.calc_ico_col(lug.main_num).col_main;
        lugar_cant.text = lug.main_num.ToString();

    }




    public void select_lug()
    {
        if (lug.inits_obj[0].inits_obj1[actual.id_num].completed == false)
        {
            all.SetActive(true);
            list_choice = lug.inits_obj[0].inits_obj1[actual.id_num].choice_obj;

            id_actual = 0;
            def(list_choice[id_actual]);
        }

            
    }


    public void make_selection(bool check)
    {
        if(lug.inits_obj[0].inits_obj1[actual.id_num].completed == true)
        {
            // warning ya esta reparado

        }
        else
        {
            if (check == list_choice[id_actual].choice_aceptar_true)
            {
                //correcto
                for (int i = 0; i < 4; i++)
                {
                    lug.area[i].area_num = lug.area[i].area_num - list_choice[id_actual].cantidad;

                    if (lug.area[i].area_num < 1)
                    {
                        lug.area[i].area_num = 1;
                    }
                    else if (lug.area[i].area_num > 10)
                    {
                        lug.area[i].area_num = 10;
                    }
                }

                calculate_main();
            }



            if (id_actual == 2)
            {
                all.SetActive(false);
                main.lug_actual.set_col_img();
                lug.inits_obj[0].inits_obj1[actual.id_num].completed = true;

                actual.restart_points();
                actual.estado_actual = 0;
            }
            else
            {
                id_actual++;
                def(list_choice[id_actual]);
            }

        }


        
    }



}


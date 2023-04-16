using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ini_obj_main : MonoBehaviour
{
    public Main_Data main;
    public GameObject all;
    public Image main_ico;
    public Image main_num_ico;
    public TextMeshProUGUI main_num;
    public TextMeshProUGUI main_nom;
    public Image main_decor;

    public Image character_img;
    public Image character_dialog;
    public TextMeshProUGUI character_nom;
    public TextMeshProUGUI character_chat;

    public List<initiative_txt> initiatives = new List<initiative_txt>();
    Lugar_main main_obj;
    public int main_area;
    public Actual_situation actual_num;
    public Ini_main ini_main_obj;

    public void def_area(int area)
    {
        if (main.area_point_obj[area].puntos == 0 || main_obj.area[area].area_num == 1)
        {



        }
        else
        {
            all.SetActive(true);
            SO_Characters2 character_p = new SO_Characters2();
            main_area = area;
            Debug.Log("SELECCIONADO " + area);

            switch (area)
            {
                case 0:
                    character_p = main.main.characters_area[0];
                    break;

                case 1:
                    character_p = main.main.characters_area[1];
                    break;

                case 2:
                    character_p = main.main.characters_area[2];
                    break;

                case 3:
                    character_p = main.main.characters_area[3];
                    break;
            }

            main_ico.sprite = character_p.icon;
            main_obj = main.lug_actual.lug;

            main_data_obj obj;
            Area_info area_main = main_obj.area[area];
            int num_final = area_main.area_num;

            obj = main.main.calc_ico_col(num_final);
            main_num_ico.color = obj.col_main;
            main_num.text = num_final.ToString();
            main_nom.text = area_main.nom;
            main_decor.color = character_p.color;

            character_img.sprite = character_p.character;
            character_dialog.sprite = character_p.characterDialog;
            character_nom.text = character_p.characterName;
            character_chat.text = character_p.characterMessage;


            //definir iniciativas actuales

            initiatives[0].ini_nom.text = main_obj.ini1.ini_nom;
            initiatives[0].ini_desc.text = main_obj.ini1.ini_desc;
            initiatives[0].id = 0;
            initiatives[0].but.sprite = character_p.change_but;

            initiatives[1].ini_nom.text = main_obj.ini2.ini_nom;
            initiatives[1].ini_desc.text = main_obj.ini2.ini_desc;
            initiatives[1].id = 1;
            initiatives[1].but.sprite = character_p.change_but;

            initiatives[2].ini_nom.text = main_obj.ini3.ini_nom;
            initiatives[2].ini_desc.text = main_obj.ini3.ini_desc;
            initiatives[2].id = 2;
            initiatives[2].but.sprite = character_p.change_but;


        }

               

    }

    public void select_initiative(int a)
    {
        
       
        int num_f = main_obj.inits_obj[main_area].inits_obj1[actual_num.id_num].init[a].num;
        main_obj.area[main_area].area_num = main_obj.area[main_area].area_num - num_f;

        if(main_obj.area[main_area].area_num<1)
        {
            main_obj.area[main_area].area_num = 1;
        }
        else if(main_obj.area[main_area].area_num>10)
        {
            main_obj.area[main_area].area_num = 10;
        }


        ini_main_obj.sendinfo(main.lug_actual.lug);
        all.SetActive(false);

        main.area_point_obj[main_area].puntos--;


        main.check_puntos();


    }

}


[System.Serializable]
public class initiative_txt
{
    public int id;
    public TextMeshProUGUI ini_nom;
    public TextMeshProUGUI ini_desc;
    public Image but;
}


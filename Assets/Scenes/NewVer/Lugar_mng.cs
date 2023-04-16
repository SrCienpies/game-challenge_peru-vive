using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Lugar_mng : MonoBehaviour
{
    public Main_Data main_data1;
    public Lugar_main lug;
    // UI
    public TextMeshProUGUI num_main_txt;
    public TextMeshProUGUI nom_txt;
    public Image main_ico;
    public Image num_ico;
    public Sprite num_ico2;

    // Start is called before the first frame update
    void Start()
    {
        nom_txt.text = lug.nombre;

        for (int i = 0; i < lug.area.Count; i++)
        {
            int num = Random.Range(5, 9);
            lug.area[i].area_num = num;

        }



    }

    


    // Update is called once per frame
    void Update()
    {
        lug.calculate_num();
        num_main_txt.text = lug.main_num.ToString();
        set_col_img();
    }

    public void set_col_img()
    {
        main_data_obj obj;
        obj = main_data1.main.calc_ico_col(lug.main_num);

        main_ico.sprite = obj.ico_main;
        num_ico.color = obj.col_main;



    }

    public void checkall()
    {
        GameObject[] all_objs;
        all_objs = GameObject.FindGameObjectsWithTag("Player");

        List<Lugar_mng> lista_lugar = new List<Lugar_mng>();
        for (int i = 0; i < all_objs.Length; i++)
        {
            lista_lugar.Add(all_objs[i].GetComponent<Lugar_mng>());
        }

        if(lista_lugar[0].lug.main_num == 1 && lista_lugar[1].lug.main_num == 1 && lista_lugar[2].lug.main_num == 1 && lista_lugar[3].lug.main_num == 1 && lista_lugar[4].lug.main_num == 1 )
        {
            Debug.Log("WIN STATE");
        }
        else
        {
            for (int i = 0; i < lista_lugar.Count; i++)
            {
                if (lista_lugar[i].lug.main_num == 10)
                {
                    Debug.Log("LOSE STATE");

                }
            }
        }


        


    }

}

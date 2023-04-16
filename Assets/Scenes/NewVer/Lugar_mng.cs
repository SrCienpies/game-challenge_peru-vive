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

    // Start is called before the first frame update
    void Start()
    {
        nom_txt.text = lug.nombre;
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

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SNormal : ScriptableObject
{
    public string cityName;
    public Sprite cityBackground;
    [Space(10)]
    public List<Initiative> planificaicon = new List<Initiative>();
    public List<Initiative> social = new List<Initiative>();
    public List<Initiative> medioAmbiente = new List<Initiative>();
    public List<Initiative> economia = new List<Initiative>();
}

[System.Serializable]
public class Area
{
    public enum Areaname { Planificacion,Social,MedioAmbiente,Economia}
    public Areaname area_name1;
    public List<Initiative> iniciatives = new List<Initiative>();
}


[System.Serializable]
public class Initiative
{
    public string Nombre;
    public string Desc;
    public enum level { A, B , C };
    public level levelnum;
}

   
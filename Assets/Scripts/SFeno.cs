using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]

public class SFeno : ScriptableObject
{
    public List<SimpleQuestion> simple = new List<SimpleQuestion>();
    public ComplexQuestion complex;
}

[System.Serializable]

public class SimpleQuestion
{
    public string Nombre;
    [TextArea]
    public string Descripcion;
    public bool Aceptar;
}

[System.Serializable]
public class ComplexQuestion
{
    public string Nombre;
    [TextArea]
    public string Descripcion;
    public List<ComplexQuestion_option> options;
}

[System.Serializable]
public class ComplexQuestion_option
{
    public string Nombre;
    [TextArea]
    public string Descripcion;
    public enum level { A, B, C };
    public level levelnum;
}

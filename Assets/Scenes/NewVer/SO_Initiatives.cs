using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SO_Initiatives : ScriptableObject
{
    public List<initiative> init = new List<initiative>();
    public List<choice> choice_obj = new List<choice>();
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Character_Save : ScriptableObject
{
    public List<bool> HeadPartSave;
    public List<bool> LegsPartSave;
    public List<bool> ShirtPartsave;
    public List<bool> ArmsPartsave;
    public List<bool> AccessoriesPartsave;
    public List<bool> WeponsPartsave;
    public List<bool> EyesPartsave;
}
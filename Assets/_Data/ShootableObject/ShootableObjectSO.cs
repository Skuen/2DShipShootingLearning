using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShootableObject", menuName = "ScriptableObjects/ShootableObject")]
public class ShootableObjectSO : ScriptableObject
{
    public string objName = "Shootable Oject";
    public ObjectType objType = ObjectType.None;
    public int hpMax = 2;
    public List<DropRate> dropList;
}

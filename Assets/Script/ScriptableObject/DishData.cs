using Unity.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "DsihData", menuName = "Scriptable Objects/DsihData")]
public class DishData : ScriptableObject
{
    public string dishName;
    public string description;
    public Sprite dishImage;
    
}

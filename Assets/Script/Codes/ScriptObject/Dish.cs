using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewDish", menuName = "Cooking/Dish")]
public class Dish : ScriptableObject
{
    public string dishName;
    public List<string> requiredSteps;

    
}

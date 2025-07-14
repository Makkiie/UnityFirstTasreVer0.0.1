using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "Recipe/Correct RecipeData")]
public class RecipeData : ScriptableObject
{

    public string recipeName;
    public List<IngredientData> correctOrder = new List<IngredientData>();

}

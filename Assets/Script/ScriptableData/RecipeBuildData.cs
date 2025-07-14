using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[CreateAssetMenu(fileName = "RecipeBuild", menuName = "Recipe/Player Build")]
public class RecipeBuildData : ScriptableObject
{

    public List<IngredientData> currentBuild = new List<IngredientData>();

    public void AddIngredient(IngredientData ingredient)
    {
        currentBuild.Add(ingredient);
    }
    public void ClearBuild()
    {
        currentBuild.Clear();
    }

}

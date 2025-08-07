using UnityEngine;

[CreateAssetMenu(fileName = "NewRecipe", menuName = "Cooking/Recipie")]
public class RecipeOS : ScriptableObject
{
    [System.Serializable]
    public class RecipeStep
    {
        public string StepName;
        public IngredientType requiredIngredient;
        public CookingToolType requiredTool;

    }
    public RecipeStep steps;

}
public enum IngredientType { ChoppedPork, Garlic, Onion, SoySauce }
public enum CookingToolType { Pan, PanLid, None}

using UnityEngine;

[CreateAssetMenu(fileName = "Ingredients", menuName = "Recipe/Ingredients")]
public class IngredientData : ScriptableObject
{

    public string ingredientName;
    public string ingredientID;
    public Sprite icon;
    
}

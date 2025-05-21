using UnityEngine;


[CreateAssetMenu(fileName = "New Ingredients", menuName ="Assets/Items/Item_Ingredients_Prefab")]
public class Items_ingredients : ScriptableObject
{
    public int ItemID;
    public string ingredientsName;
    public Sprite Icon;
    public GameObject prefab;
   // public enum IngredientsState;
}

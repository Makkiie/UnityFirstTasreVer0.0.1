using UnityEngine;

[CreateAssetMenu(fileName = "NewHdialogData", menuName = "HDialogSystem/HdialogData")]
public class HdialogData : ScriptableObject
{
    [System.Serializable]
    public class HDialogLine
    {
        [TextArea] public string text;   // Dialog text
        
    }
    public Sprite dishSprite;        // Dish image
    public HDialogLine[] hDialogLines;
}

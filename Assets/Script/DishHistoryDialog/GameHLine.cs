using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewDialogLine", menuName = "DishHistory/GameDialogLine")]
public class GameHLine : ScriptableObject
{
    [TextArea]
    public string GamedialogText;

    public Button uiToHighlight;     // Must be UnityEngine.UI.Button
    public bool waitForClickOnUI;
}

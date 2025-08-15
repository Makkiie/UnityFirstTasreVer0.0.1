using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewDialogLine", menuName = "Tutorial/Dialog Line")]
public class UIDialogLine : ScriptableObject
{
    [TextArea]
    public string dialogText;

    public string uiElementName;     // Must be UnityEngine.UI.Button
    public bool waitForClickOnUI;
}

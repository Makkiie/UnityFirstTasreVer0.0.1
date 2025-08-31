using UnityEngine;
using UnityEngine.UI;

public class ButtonTransfer : MonoBehaviour
{
    public Button cabinetButton;    // first button
    public Button tableButton;      // second button
    public Image ingredient;        // ingredient image

    private void Start()
    {
        ingredient.gameObject.SetActive(false); // hide at start
        cabinetButton.onClick.AddListener(MoveToTable);
    }

    void MoveToTable()
    {
        // Show the ingredient on the table button
        ingredient.gameObject.SetActive(true);

        // Move ingredient image position to table button
        ingredient.rectTransform.position = tableButton.transform.position;

        // (Optional) Disable cabinet button after use
        cabinetButton.interactable = false;
    }
}
using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour
{
    [Header("UI References")]
    public Text titleText;
    public Text descriptionText;
    public Image dishImage;

    public void SetDishData(DishData dishData)
    {
        titleText.text = dishData.dishName;
        descriptionText.text = dishData.description;
        dishImage.sprite = dishData.dishImage;
    }

}

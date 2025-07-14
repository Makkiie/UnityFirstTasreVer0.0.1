using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IndicatorController : MonoBehaviour
{
    public DishData dishData;
    public int levelIndex;

    [Header("Info Panel Reference")]
    public GameObject infoPanel;
    public Image dishImageDisplay;
    public TextMeshProUGUI dishTitleDisplay;
    public TextMeshProUGUI Score;

    [Header("Button and Visual")]
    public Image buttonImage;
    public Color lockedColor = Color.gray;
    public Color unlockedColor = Color.white;

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        SetupIndicator();
    }

    void SetupIndicator()
    {
        int previousScore = PlayerPrefs.GetInt($"Level{levelIndex - 1}_Score", 0);

        bool isUnlocked = (levelIndex == 0) || (previousScore >= 75);

        if (buttonImage != null)
            buttonImage.color = isUnlocked ? unlockedColor : lockedColor;
        if (button != null)
            button.interactable = isUnlocked;
    }
    public void ShowDishInfo()
    {
        if (dishData == null || infoPanel == null) return;

        infoPanel.SetActive(true);
        dishImageDisplay.sprite = dishData.dishImage;
        dishTitleDisplay.text = dishData.dishTitle;

        //Score Display
        int levelScore = PlayerPrefs.GetInt($"Level{levelIndex}_Score", 0);

        if (levelScore > 0)
        {
            Score.gameObject.SetActive(true);
            Score.text = $"Score: {levelScore}";
        }
        else
        {
            Score.gameObject.SetActive(false);
        }

    }
}

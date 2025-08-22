using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class UITutorialManager : MonoBehaviour
{
    public UIDialogLine[] dialogLines;

    public GameObject dialogCanvas;
    public GameObject mapMainCanvas;
    public GameObject settingCanvas;

    public TextMeshProUGUI dialogText;

    public Button dialogBoxButton;

    private int currentLine = 0;
    private bool waitingForClick = false;
    private bool readyToAdvance = false;

    void Start()
    {
        //Count for the tutorial
        if (PlayerPrefs.GetInt("TutorialDone", 0) == 5)
        {
            dialogCanvas.SetActive(false);
            return;
        }

        dialogBoxButton.onClick.AddListener(OnDialogBoxClicked);
        StartCoroutine(PlayTutorial());
    }

    IEnumerator PlayTutorial()
    {
        dialogCanvas.SetActive(true);
        mapMainCanvas.SetActive(true);
        settingCanvas.SetActive(false);

        while (currentLine < dialogLines.Length)
        {
            UIDialogLine line = dialogLines[currentLine];

            yield return StartCoroutine(TypeText(line.dialogText));

            readyToAdvance = false;

            Button buttonToHighlight = null;

            if (!string.IsNullOrEmpty(line.uiElementName))
            {
                GameObject uiObj = GameObject.Find(line.uiElementName);
                if (uiObj != null)
                {
                    buttonToHighlight = uiObj.GetComponent<Button>();
                    HighlightUI(uiObj);
                }
            }
            if (line.waitForClickOnUI && buttonToHighlight != null)
            {
                waitingForClick = true;
                buttonToHighlight.onClick.AddListener(() => OnUIElementClicked(buttonToHighlight));
                yield return new WaitUntil(() => !waitingForClick);
            }
            else
            {
                yield return new WaitUntil(() => readyToAdvance);
            }

            currentLine++;
        }

        dialogCanvas.SetActive(false);
        PlayerPrefs.SetInt("TutorialDone", 1);
    }

    void HighlightUI(GameObject ui)
    {
        // Optional: Highlight effect
        // Example: change color, add outline, or scale
        var image = ui.GetComponent<Image>();
        if (image != null)
            image.color = Color.white; // TEMPORARY highlight

        // Add pulse animation here if you want
    }

    void OnUIElementClicked(Button button)
    {
        waitingForClick = false;
        button.onClick.RemoveAllListeners();
    }

    void OnDialogBoxClicked()
    {
        if (!waitingForClick)
        {
            readyToAdvance = true;
        }
    }
    IEnumerator TypeText(string textToType)
    {
        dialogText.text = "";
        foreach (char c in textToType)
        {
            dialogText.text += c;
            yield return new WaitForSeconds(0.02f); // Adjust speed here
        }

    }
}
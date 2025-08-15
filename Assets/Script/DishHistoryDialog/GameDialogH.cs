using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class GameDialogH : MonoBehaviour
{
    public UIDialogLine[] dialogLines;

    public GameObject HdialogCanvas;
    public GameObject Level1game; //Level Canvas
    public GameObject settingCanvas;

    public TextMeshProUGUI GamedialogText;

    public Button GamedialogBoxButton;

    private int GcurrentLine = 0;
    private bool GwaitingForClick = false;
    private bool GreadyToAdvance = false;

    void Start()
    {
        if (PlayerPrefs.GetInt("TutorialDone", 0) == 1)
        {
            HdialogCanvas.SetActive(false);
            return;
        }

        GamedialogBoxButton.onClick.AddListener(OnDialogBoxClicked);
        StartCoroutine(PlayTutorial());
    }

    IEnumerator PlayTutorial()
    {
        HdialogCanvas.SetActive(true);
        Level1game.SetActive(true);
        settingCanvas.SetActive(false);

        while (GcurrentLine < dialogLines.Length)
        {
            UIDialogLine line = dialogLines[GcurrentLine];

            yield return StartCoroutine(TypeText(line.dialogText));

            GreadyToAdvance = false;

            //if (line.uiToHighlight != null)
               // HighlightUI(line.uiToHighlight.gameObject);

           // if (line.waitForClickOnUI && line.uiToHighlight != null)
           // {
            //    GwaitingForClick = true;
            //    line.uiToHighlight.onClick.AddListener(() => OnUIElementClicked(line.uiToHighlight));
          //      yield return new WaitUntil(() => !GwaitingForClick);
           // }
           // else
           // {
           //     yield return new WaitUntil(() => GreadyToAdvance);
          //  }

            GcurrentLine++;
        }

        HdialogCanvas.SetActive(false);
        PlayerPrefs.SetInt("TutorialDone", 1);
    }

    void HighlightUI(GameObject ui)
    {
        // Optional: Highlight effect
        // Example: change color, add outline, or scale
        var image = ui.GetComponent<Image>();
        if (image != null)
            image.color = Color.yellow; // TEMPORARY highlight

        // Add pulse animation here if you want
    }

    void OnUIElementClicked(Button button)
    {
        GwaitingForClick = false;
        button.onClick.RemoveAllListeners();
    }

    void OnDialogBoxClicked()
    {
        if (!GwaitingForClick)
        {
            GreadyToAdvance = true;
        }
    }
    IEnumerator TypeText(string textToType)
    {
        GamedialogText.text = "";
        foreach (char c in textToType)
        {
            GamedialogText.text += c;
            yield return new WaitForSeconds(0.02f); // Adjust speed here
        }

    }
}
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SliderAnimationController : MonoBehaviour
{
    public Animator InfoPanelAnimator;

    public void SlideInfoPanel()
    {
        if (InfoPanelAnimator != null)
        {
            InfoPanelAnimator.Play("SlideIn");
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

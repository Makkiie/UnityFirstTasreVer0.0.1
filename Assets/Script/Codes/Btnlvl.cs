using UnityEngine;

public class Btnlvl : MonoBehaviour
{
   public DishData dishData;
    public InfoPanel infoPanel;

    public Animator animator;

    public void OnButtonClick()
    {
        infoPanel.SetDishData(dishData);
        animator.SetTrigger("Open");
    }
}

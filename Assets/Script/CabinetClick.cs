using UnityEngine;

public class CabinetClick : MonoBehaviour
{
    public GameObject ingredient; // drag the ingredient here in Inspector
    private bool isTaken = false;

    void OnMouseDown()  // works if it has a collider & camera has Physics2DRaycaster
    {
        if (!isTaken)
        {
            ingredient.SetActive(true);  // show ingredient on table
            isTaken = true;
        }
    }
}
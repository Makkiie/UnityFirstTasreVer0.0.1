using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DragDrop2D : MonoBehaviour
{
    private Camera cam;
    private Vector3 offset;
    private Vector3 originalPosition;
    private bool isDragging = false;

    void Start()
    {
        cam = Camera.main;
        originalPosition = transform.position; // Save start position
    }

    void OnMouseDown()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - new Vector3(mousePos.x, mousePos.y, 0);
        isDragging = true;
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePos.x, mousePos.y, 0) + offset;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;

        // Check if the item is released on a DropSlot
        Collider2D hit = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        if (hit != null && hit.CompareTag("DropSlot"))
        {
            // Snap to the slot position
            transform.position = hit.transform.position;
        }
        else
        {
            // Go back to original position
            transform.position = originalPosition;
        }
    }
}

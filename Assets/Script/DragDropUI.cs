using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Canvas canvas;
    private Vector3 originalPosition;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = rectTransform.position;  // Save start pos
        canvasGroup.alpha = 0.6f;                   // Make transparent while dragging
        canvasGroup.blocksRaycasts = false;         // Allow raycasts to pass through
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        // If not dropped on a valid slot → return to start
        if (!eventData.pointerEnter || !eventData.pointerEnter.CompareTag("DropSlot"))
        {
            rectTransform.position = originalPosition;
        }
        else
        {
            // Snap to slot center
            rectTransform.position = eventData.pointerEnter.transform.position;
        }
    }
}

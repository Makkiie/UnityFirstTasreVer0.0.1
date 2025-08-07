using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlotInv : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if(transform.childCount == 0)
        {
            ItemInv itemInv =eventData.pointerDrag.GetComponent<ItemInv>();
            itemInv.parentAfterDrag = transform;
        }
    }
}

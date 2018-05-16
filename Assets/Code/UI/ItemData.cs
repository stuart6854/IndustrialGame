using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemData : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler {

    public Item item;
    public Image icon;

    public int slot;
    
    private Vector2 offset;

    public void SetItem(Item _item, int _slot) {
        item = _item;
        slot = _slot;

        //icon.sprite = item.icon;
    }    

    public void OnPointerDown(PointerEventData eventData) {
        if(item != null) {
            offset = eventData.position - (Vector2)transform.position;
            transform.SetParent(transform.parent.parent);
            transform.position = eventData.position;
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData) {
        if(item != null) {
            transform.position = eventData.position - offset;
        }
    }

    public void OnEndDrag(PointerEventData eventData) {
        transform.SetParent(Inventory.instance.inventoryUI.slots[slot].transform);
        transform.localPosition = Vector2.zero;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}

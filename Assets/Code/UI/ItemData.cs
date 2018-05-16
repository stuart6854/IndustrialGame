using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public Item item;
    public Image icon;

    public int slot;
    
    private Vector2 offset;

    public void SetItem(Item _item, int _slot) {
        item = _item;
        slot = _slot;

        icon.sprite = item.icon;
    }    

    public void OnBeginDrag(PointerEventData eventData) {
        print("OnPointerDown");
        if(item != null) {
            GetComponent<CanvasGroup>().blocksRaycasts = false;
            offset = eventData.position - (Vector2)transform.position;
            transform.SetParent(transform.GetComponentInParent<Canvas>().transform);
            transform.position = eventData.position;
        }
    }

    public void OnDrag(PointerEventData eventData) {
        if(item != null) {
            transform.position = eventData.position - offset;
        }
    }

    public void OnEndDrag(PointerEventData eventData) {
        print("OnEndDrag");
        transform.SetParent(Inventory.instance.inventoryUI.GetSlot(slot).transform);
        transform.localPosition = Vector2.zero;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}

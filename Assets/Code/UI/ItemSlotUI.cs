using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlotUI : MonoBehaviour, IDropHandler {

    public int id;

    public void OnDrop(PointerEventData eventData) {
        ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();
        if(Inventory.instance.GetSlot(id).id == -1) {
            Inventory.instance.SetSlot(droppedItem.slot, new Item());
            Inventory.instance.SetSlot(id, droppedItem.item);
            droppedItem.slot = id;
        }
    }

}

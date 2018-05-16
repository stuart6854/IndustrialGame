using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler {

    public int id;

    public void OnDrop(PointerEventData eventData) {
        ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();
        if(Inventory.instance.items[id].id == -1) {
            Inventory.instance.items[droppedItem.slot] = new Item();
            Inventory.instance.items[id] = droppedItem.item;
            droppedItem.slot = id;
        }
    }

}

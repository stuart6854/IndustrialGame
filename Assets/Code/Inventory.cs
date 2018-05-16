using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public static Inventory instance { get; private set; }

    public static readonly int hotbarSlotAmnt = 10;     //Amount of items that can be held
    public static readonly int inventorySlotAmnt = 30;  //Amount of items that can be held
    
    public InventoryUI inventoryUI { get; private set; }

    public readonly int totalSlotAmnt = hotbarSlotAmnt + inventorySlotAmnt;

    private List<Item> items = new List<Item>();

    private void Awake() {
        if(instance != null)
            Destroy(this);

        instance = this;
        inventoryUI = FindObjectOfType<InventoryUI>();
    }

    private void Start() {
        for(int i = 0; i < totalSlotAmnt; i++)
            items.Add(new Item());

        Item item = new Item();
        item.id = 1;
        AddItem(item);
    }

    public void AddItem(Item _item) {
        for(int i = 0; i < totalSlotAmnt; i++) {
            if(items[i].id != -1)
                continue;
            
            items[i] = _item;
            if(_item.id != -1) {
                if(i < hotbarSlotAmnt)
                    inventoryUI.AddItem(i, _item);
            }

            break;
        }

    }

    public void SetSlot(int _slot, Item _item) {
        items[_slot] = _item;
    }

    public Item GetSlot(int _slot) {
        return items[_slot];
    }

    public void Remove(Item _item) {
        items.Remove(_item);
    }

}

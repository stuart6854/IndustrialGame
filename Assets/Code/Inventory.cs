using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public static Inventory instance;
    public InventoryUI inventoryUI { get; private set; }

    public int slotAmount = 30; //Amount of items that can be held

    public List<Item> items = new List<Item>();

    private void Awake() {
        if(instance != null)
            Destroy(this);

        instance = this;
        inventoryUI = FindObjectOfType<InventoryUI>();
    }

    private void Start() {
        for(int i = 0; i < slotAmount; i++)
            items.Add(new Item());

        Item item = new Item();
        item.id = 1;
        AddItem(item);
    }

    public void AddItem(Item _item) {
        for(int i = 0; i < slotAmount; i++) {
            if(items[i].id != -1)
                continue;
            
            items[i] = _item;
            if(_item.id != -1)
                inventoryUI.AddItem(i, _item);

            break;
        }

    }

    public void Remove(Item _item) {
        items.Remove(_item);
    }

}

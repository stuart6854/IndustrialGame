using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour {

    public int storageSize = 50;

    public StorageUI storageUI { get; private set; }

    private List<Item> items = new List<Item>();

    private void Awake() {
        storageUI = FindObjectOfType<StorageUI>();
    }

    void Start () {
        storageUI.ClearSlots();
        for(int i = 0; i < storageSize; i++)
            items.Add(new Item());

        Item item = new Item();
        item.id = 1;
        AddItem(item);
    }


    public void AddItem(Item _item) {
        for(int i = 0; i < storageSize; i++) {
            if(items[i].id != -1)
                continue;

            items[i] = _item;
            if(_item.id != -1) {
                //storageUI.AddItem(i, _item);
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

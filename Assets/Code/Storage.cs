using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour {

    public int storageSize;

    public StorageUI storageUI;

    private List<Item> items = new List<Item>();

    void Start () {
        AddItem(ItemDatabase.GetItem("wood", 5));
        AddItem(ItemDatabase.GetItem("metal", 128));
    }

    public void AddItems(Item[] _items) {
        foreach(Item item in _items)
            AddItem(item, false);

        RefreshUI();
    }

    public bool AddItem(Item _item, bool refreshUI = true) {
        if(_item.itemSlug == "") 
            return false; // Dont add blank items
        
        if(items.Count < storageSize)
            items.Add(_item);

        if(refreshUI)
            RefreshUI();

        return true;
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

    private void RefreshUI() {
        if(storageUI.IsVisible())
            storageUI.RefreshUI(items);
    }

}

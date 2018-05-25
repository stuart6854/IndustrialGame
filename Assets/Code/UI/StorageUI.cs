using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageUI : MonoBehaviour {

    public GameObject storageUI;
    public Transform storagePanel;
    [Space]
    public GameObject itemPrefab;

    public void RefreshUI(List<Item> _storageItems) {
        ClearSlots();
        foreach(Item item in _storageItems)
            AddItem(item);
    }

    private void AddItem(Item _item) {
        GameObject itemObj = Instantiate(itemPrefab);
        itemObj.transform.SetParent(storagePanel, false);

        itemObj.GetComponent<ItemData>().SetItem(_item);
    }

    private void ClearSlots() {
        foreach(Transform child in storagePanel.transform) {
            Destroy(child.gameObject);
        }
    }

    public bool IsVisible() {
        return storageUI.activeSelf;
    }

}

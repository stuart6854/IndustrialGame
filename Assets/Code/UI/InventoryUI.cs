using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {

    public GameObject inventoryUI;
    public Transform slotPanel;
    public GameObject slotPrefab;
    public GameObject itemPrefab;

    private Inventory inventory;

    public List<GameObject> slots = new List<GameObject>();

    void Start () {
        inventory = Inventory.instance;

        for(int i = 0; i < inventory.slotAmount; i++) {
            slots.Add(Instantiate(slotPrefab));
            slots[i].transform.SetParent(slotPanel.transform, false);
            slots[i].GetComponent<InventorySlot>().id = i;
        }
    }

	void Update () {
        if(Input.GetButtonDown("Inventory")) {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
	}

    public void AddItem(int _slot, Item _item) {
        GameObject itemObj = Instantiate(itemPrefab);
        itemObj.transform.SetParent(slots[_slot].transform);
        itemObj.transform.localPosition = Vector2.zero;

        itemObj.GetComponent<ItemData>().SetItem(_item, _slot);
    }

}

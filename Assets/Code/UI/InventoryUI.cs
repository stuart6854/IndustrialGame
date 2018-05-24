using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {
    
    public GameObject itemPrefab;
    [Space]
    public GameObject inventoryUI;
    public Transform inventorySlotPanel;
    [Space]
    public GameObject hotbarUI;
    public GameObject hotbarSlotPanel;

    private Inventory inventory;

    private List<GameObject> slots = new List<GameObject>();

    void Start () {
        inventory = Inventory.instance;

        //for(int i = 0; i < inventory.totalSlotAmnt; i++) {
        //    slots.Add(Instantiate(slotPrefab));
        //    slots[i].GetComponent<ItemSlotUI>().id = i;
        //    if(i < Inventory.hotbarSlotAmnt)
        //        slots[i].transform.SetParent(hotbarSlotPanel.transform, false);
        //    else
        //        slots[i].transform.SetParent(inventorySlotPanel, false);
        //}
    }

	void Update () {
        if(Input.GetButtonDown("Inventory")) {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
	}

    public void AddItem(int _slot, Item _item) {
        GameObject itemObj = Instantiate(itemPrefab);
        itemObj.transform.SetParent(inventorySlotPanel, false);

        itemObj.GetComponent<ItemData>().SetItem(_item);
    }

    public GameObject GetSlot(int _slot) {
        return slots[_slot];
    }

}

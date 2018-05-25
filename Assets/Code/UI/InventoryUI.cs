using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : StorageUI {
    
	void Update () {
        if(Input.GetButtonDown("Inventory")) {
            storageUI.SetActive(!IsVisible());
        }
	}

}

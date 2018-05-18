using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageUI : MonoBehaviour {

    public GameObject slotPanel;

    public void ClearSlots() {
        foreach(Transform child in slotPanel.transform) {
            Destroy(child.gameObject);
        }
    }

}

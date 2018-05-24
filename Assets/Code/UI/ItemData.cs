using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemData : MonoBehaviour {

    public Item item;
    public Text itemName;
    public Text itemAmnt;

    public void SetItem(Item _item) {
        item = _item;

        itemName.text = item.itemName;
        itemAmnt.text = "" + item.amnt;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {

    public string itemSlug;
    public string itemName;
    public string description;

    public string icon;

    public int amnt;

    //private GameObject obj;
    //public float beltTime;

    public Item() {
        itemSlug = "";
        itemName = "null_item_name";
        description = "null_item_desc";
    }

    public Item(Item _copyFrom) {
        itemSlug = _copyFrom.itemSlug;
        itemName = _copyFrom.itemName;
        description = _copyFrom.description;
        icon = _copyFrom.icon;
    }

    public Item(Item _copyFrom, int _amnt) : this(_copyFrom) {
        amnt = _amnt;
    }

    public GameObject CreateItemObj(Vector3 pos) {
        DestroyObject();

        GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        obj.transform.position = pos;
        obj.transform.localScale = new Vector3(0.1f, 0.1f, 0.2f);
        obj.AddComponent<BoxCollider>();
        obj.AddComponent<ItemObj>().item = this;

        return obj;
    }

    public GameObject GetObject() {
        return null;// obj;
    }

    public void DestroyObject() {
        //Object.Destroy(obj);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {

    public int id = -1;
    public string itemSlug; //Item Dictionary Identifier
    public Sprite icon;

    private GameObject obj;
    public float beltTime;

    public GameObject CreateItemObj(Vector3 pos) {
        DestroyObject();

        obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        obj.transform.position = pos;
        obj.transform.localScale = new Vector3(0.1f, 0.1f, 0.2f);
        obj.AddComponent<BoxCollider>();
        obj.AddComponent<ItemObj>().item = this;

        return obj;
    }

    public GameObject GetObject() {
        return obj;
    }

    public void DestroyObject() {
        Object.Destroy(obj);
    }

}

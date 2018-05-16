using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour {

    public GameObject tempItemPrefab;

    private static readonly float CONVEYOR_SPEED = 0.5f;
    private static readonly float ITEM_SEP_DIST = 0.1f;
    
    public Transform inputPos, outputPos;

    private List<Item> beltItems = new List<Item>();

    private void Start() {
        InputItem(new Item());

        Invoke("Start", 1);
    }

    private void Update() {
        List<Item> toOutput = new List<Item>();
        for(int i = 0; i < beltItems.Count; i++) {
            Item item = beltItems[i];
            Item leadItem = null;
            if(i - 1 >= 0)
                leadItem = beltItems[i - 1];

            if(leadItem != null)
                if(Vector3.Distance(item.obj.transform.position, leadItem.obj.transform.position) < ITEM_SEP_DIST)
                    continue;


            item.beltTime = Mathf.Clamp01(item.beltTime + Time.deltaTime * CONVEYOR_SPEED);
            item.obj.transform.position =  GetBezierPosition(item.beltTime);
            item.obj.transform.LookAt(GetBezierPosition(item.beltTime + Time.deltaTime));

            if(item.beltTime >= 1) {
                toOutput.Add(item);
            }
        }

        foreach(Item item in toOutput) {
            OutputItem(item);
        }

    }

    public bool InputItem(Item _item) {
        if(beltItems.Count > 0 && Vector3.Distance(inputPos.position, beltItems[beltItems.Count - 1].obj.transform.position) < ITEM_SEP_DIST)
            return false;

        _item.obj = Instantiate(tempItemPrefab);
        _item.beltTime = 0;
        _item.obj.transform.position = inputPos.position;
        beltItems.Add(_item);

        return true;
    }

    public bool OutputItem(Item _item) {
        _item.obj.transform.position = outputPos.position;
        
        //if can output to belt or machine
            //_item.beltTime = 0;
            //beltItems.Remove(_item);
            //Destroy(_item.obj);

            //Managed to output in machine or onto other conveyor belt
            return true;
        //else
            //return false;
    }

    // parameter t ranges from 0f to 1f
    // this code might not compile!
    Vector3 GetBezierPosition(float t) {
        Vector3 p0 = inputPos.position;
        Vector3 p1 = p0 + inputPos.forward * 0.5f;
        Vector3 p3 = outputPos.position;
        Vector3 p2 = p3 - (-outputPos.forward) * 0.5f;

        // here is where the magic happens!
        return Mathf.Pow(1f - t, 3f) * p0 + 3f * Mathf.Pow(1f - t, 2f) * t * p1 + 3f * (1f - t) * Mathf.Pow(t, 2f) * p2 + Mathf.Pow(t, 3f) * p3;
    }

    private int roundUp(int numToRound, int multiple) {
        if(multiple == 0)
            return numToRound;

        int remainder = numToRound % multiple;
        if(remainder == 0)
            return numToRound;

        return numToRound + multiple - remainder;
    }

}

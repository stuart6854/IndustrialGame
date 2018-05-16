using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour {

    public GameObject tempItemPrefab;

    private static readonly float CONVEYOR_SPEED = 0.5f;
    private static readonly float ITEM_EXTRA_DIST = 0.025f;

    public Transform inputPos, outputPos, controlPoint;

    private List<Item> beltItems = new List<Item>();

    private void Start() {

    }

    private void Update() {
        UpdateBelt();

        InputItem(new Item());
    }

    private void UpdateBelt() {
        List<Item> toOutput = new List<Item>();
        for(int i = 0; i < beltItems.Count; i++) {
            Item currentItem = beltItems[i];
            GameObject currentItemObj = currentItem.GetObject();
            Item leadItem = null;
            if(i - 1 >= 0)
                leadItem = beltItems[i - 1];

            if(leadItem != null) {
                float sepDist = currentItemObj.GetComponent<BoxCollider>().size.z / 2f * currentItemObj.transform.localScale.z;
                sepDist += leadItem.GetObject().GetComponent<BoxCollider>().bounds.size.z / 2f * leadItem.GetObject().transform.localScale.z;
                sepDist += ITEM_EXTRA_DIST;
                if(Vector3.Distance(currentItemObj.transform.position, leadItem.GetObject().transform.position) < sepDist)
                    continue;
            }

            currentItem.beltTime = Mathf.Clamp01(currentItem.beltTime + Time.deltaTime * CONVEYOR_SPEED);
            currentItemObj.transform.position =  GetPoint(currentItem.beltTime);
            currentItemObj.transform.LookAt(GetPoint(currentItem.beltTime + Time.deltaTime));

            if(currentItem.beltTime >= 1) {
                toOutput.Add(currentItem);
            }
        }

        foreach(Item item in toOutput) {
            OutputItem(item);
        }

    }

    public bool InputItem(Item _item) {
        GameObject newItemObj = _item.CreateItemObj(inputPos.position);
        newItemObj.SetActive(false); // Disable because we are only testing if can place

        if(beltItems.Count > 0) {
            Item leadItem = beltItems[beltItems.Count - 1];

            float sepDist = newItemObj.GetComponent<BoxCollider>().size.z / 2f * newItemObj.transform.localScale.z;
            sepDist += leadItem.GetObject().GetComponent<BoxCollider>().size.z / 2f * leadItem.GetObject().transform.localScale.z;
            sepDist += ITEM_EXTRA_DIST;

            print("newItem: " + newItemObj.GetComponent<BoxCollider>().size.z * newItemObj.transform.localScale.z);
            print("leadItem: " + leadItem.GetObject().GetComponent<BoxCollider>().size.z * leadItem.GetObject().transform.localScale.z);

            if(Vector3.Distance(inputPos.position, leadItem.GetObject().transform.position) < sepDist) {
                _item.DestroyObject();
                return false;
            }
        }
        newItemObj.SetActive(true); //Re-enable
        _item.beltTime = 0;
        beltItems.Add(_item);

        return true;
    }

    public bool OutputItem(Item _item) {
        _item.GetObject().transform.position = outputPos.position;
        
        //if can output to belt or machine
            //_item.beltTime = 0;
            //beltItems.Remove(_item);
            //_item.DestroyObject();

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

    public Vector3 GetPoint(float t) {
        Vector3 p0 = inputPos.position;
        Vector3 p1 = controlPoint.position;
        Vector3 p2 = outputPos.position;
        return Vector3.Lerp(Vector3.Lerp(p0, p1, t), Vector3.Lerp(p1, p2, t), t);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Storage {

    public static Inventory instance { get; private set; }

    public static readonly int hotbarSlotAmnt = 10;     //Amount of items that can be held
    
    private void Awake() {
        if(instance != null)
            Destroy(this);

        instance = this;
    }

}

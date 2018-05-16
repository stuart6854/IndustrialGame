using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour {

    public int factorySize = 16;

    private Block[,,] factory;

	void Start () {
        
	}
	
    private void LoadFactory() {
        factory = new Block[factorySize, factorySize, factorySize];

        //TODO: Load saved factory

        //If no saved factory, create blank one


        
        //Place factory door
    }

	void Update () {
	    	
	}
    
    public void SetBlock(int x, int y, int z, Block block) {
        factory[x, y, z] = block;
    }

    public Block GetBlock(int x, int y, int z) {
        return factory[x, y, z];
    }

}

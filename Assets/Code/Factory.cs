using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour {

    public int factorySize = 16;

    private Block[,,] factory;

	void Start () {
		LoadFactory ();
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

	public void OnDrawGizmos(){
		Vector3 pos = transform.position + Vector3.one * factorySize * 0.5f;
		Gizmos.DrawWireCube (pos, Vector3.one * factorySize);
	}

}

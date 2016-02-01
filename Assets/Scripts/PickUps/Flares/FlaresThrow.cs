using UnityEngine;
using System.Collections;

public class FlaresThrow : MonoBehaviour {

    public GameObject flare;
    public CharacterInventory inventory;
	
	void Update () {
        if(inventory.getCurrentFlares() > 0) {
            if (Input.GetKeyDown("f")) {
                inventory.subtractFlares(1);
                ObjectPooling.Spawn(flare, this.transform.position, this.transform.rotation);
            }
        }	    
	}
}

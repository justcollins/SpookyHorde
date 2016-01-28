using UnityEngine;
using System.Collections;


//MOST LIKELY WILL NOT NEED THIS SCRIPT
[RequireComponent(typeof (CharacterInventory))]
[RequireComponent(typeof (CharacterHealth))]
public class CharacterPickUp : MonoBehaviour {

    public HealPlayer healthPack;

    private CharacterInventory inventory;
    private CharacterHealth health;

	// Use this for initialization
	void Start () {
        inventory = GetComponent<CharacterInventory>();
        health = GetComponent<CharacterHealth>();
	}


    //Move to Flares script instead of CharacterPickUpScript
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == 11 && inventory.getCurrentFlares() <= inventory.maxFlares)
        {
            Spawner.subtractCurrentItems(1);
            ObjectPooling.DeSpawn(collider.gameObject);
            inventory.addFlares(1);
        }
    }
}

using UnityEngine;
using System.Collections;

[RequireComponent(typeof (CharacterInventory))]
[RequireComponent(typeof (CharacterHealth))]
public class CharacterPickUp : MonoBehaviour {

    public Health healthPack;

    private CharacterInventory inventory;
    private CharacterHealth health;

	// Use this for initialization
	void Start () {
        inventory = GetComponent<CharacterInventory>();
        health = GetComponent<CharacterHealth>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == 11 && inventory.getCurrentFlares() <= inventory.maxFlares)
        {
            Spawner.subtractCurrentItems(1);
            ObjectPooling.DeSpawn(collider.gameObject);
            inventory.addFlares(1);
        }/* else if (collider.gameObject.layer == 12 && health.getCurrentHealth() + <= 100) {
            Spawner.subtractCurrentItems(1);
            ObjectPooling.DeSpawn(collider.gameObject);
        } */
    }
}

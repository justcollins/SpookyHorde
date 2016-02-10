using UnityEngine;
using System.Collections;

public class FlarePickUp : MonoBehaviour {

    private CharacterInventory inventory;

    void Start () {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInventory>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player" && inventory.getCurrentFlares() <= inventory.maxFlares)
        {
            Spawner.subtractCurrentItems(1);
            ObjectPooling.DeSpawn(this.gameObject);
            inventory.addFlares(1);
        }
    }
}

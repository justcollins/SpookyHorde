using UnityEngine;
using System.Collections;

public class HealPlayer : MonoBehaviour {

    public int giveHealth = 15;

    private CharacterHealth player;
    private bool isHealing;

    public void changeHealing() {
        isHealing = !isHealing;
    }

	void Start () {
        isHealing = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterHealth>();
	}

    public void Heal() {
        if(player.getCurrentHealth() < 100 && (player.getCurrentHealth() + giveHealth) <= 100) {
            player.addCurrentHealth(giveHealth);
        } else if (player.getCurrentHealth() < 100 && (player.getCurrentHealth() + giveHealth) > 100) {
            int tempHealth = 100 - player.getCurrentHealth();
            player.addCurrentHealth(tempHealth);
        }
    }

    public void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Player" && !(player.getCurrentHealth() >= 100))
        {
            Heal();
            Spawner.subtractCurrentItems(1);
            ObjectPooling.DeSpawn(this.gameObject);
        }
    }
}

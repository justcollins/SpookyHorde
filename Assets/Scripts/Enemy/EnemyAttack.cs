using UnityEngine;

/*
Author: Justin Collins
Purpose of Script: Controls how the enemy attacks the player
    */

public class EnemyAttack : MonoBehaviour {

    public int enemyDamage = 5;
    public int timeBetweenAttacks = 2;

    private float timer = 0.0f;
    private CharacterHealth player;

    public void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterHealth>();
    }

    public void SetTimer(float setTimer) {
        this.timer = setTimer;
    }

    void OnCollisionStay(Collision collider) {
        if (collider.gameObject.tag == "Player") {
            player.setCurrentHealth(DealDamage(player.getCurrentHealth()));
        }
    }

    public int DealDamage(int damagedHealth) {
        timer += Time.deltaTime;
        if (timeBetweenAttacks <= timer) {
            SetTimer(0.0f);
            return damagedHealth -= enemyDamage;
        } else {
            return damagedHealth;
        }
    }
}

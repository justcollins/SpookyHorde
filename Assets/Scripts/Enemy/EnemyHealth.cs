using UnityEngine;
using System.Collections;

/*
Author: Justin Collins
Purpose of Script: Controls the enemie's health
    */

public class EnemyHealth : MonoBehaviour {

    public int enemyHealth = 100;

    private int enemyCurrentHealth;
    private bool isDead;

    public void Awake() {
        enemyCurrentHealth = enemyHealth;
    }

    public void OnEnable()
    {
        enemyCurrentHealth = enemyHealth;
    }

    void Update () {
        isDead = EnemyDeadCheck();

        if(isDead) {
            Spawner.subtractCurrentEnemies(1);
            ObjectPooling.DeSpawn(this.gameObject);
        }
	}

    public void TakeDamage(int damageTaken) {
        enemyCurrentHealth -= damageTaken;
    }

    public bool EnemyDeadCheck() {
        return (enemyCurrentHealth <= 0);
    }

    
}

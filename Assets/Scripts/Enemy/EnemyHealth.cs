using UnityEngine;
using System.Collections;

/*
Author: Justin Collins
Purpose of Script: Controls the enemie's health
    */

public class EnemyHealth : MonoBehaviour {

    public int enemyHealth = 100;

    private int enemyCurrentHealth;
    private Spawner spawner;
    public Animator deathAnimation;
    private bool isDead;

    public void Awake() {
        enemyCurrentHealth = enemyHealth;
    }

    public void Start() {
        spawner = FindObjectOfType<Spawner>();
        //deathAnimation = GetComponentInChildren<Animator>();
    }

    public void OnEnable() {
        deathAnimation.SetBool("Dead", false);
        enemyCurrentHealth = enemyHealth;
    }

    void Update() {
        isDead = EnemyDeadCheck();

        if (isDead) {
            this.deathAnimation.SetBool("Dead", true);
            StartCoroutine(Despawn(1.5f));
            //ObjectPooling.DeSpawn(this.gameObject);
        }
    }

    public void TakeDamage(int damageTaken) {
        enemyCurrentHealth -= damageTaken;
    }

    public bool EnemyDeadCheck() {
        return (enemyCurrentHealth <= 0);
    }

    public IEnumerator Despawn(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        spawner.SubtractCurrentEnemies(1);
        ObjectPooling.DeSpawn(this.gameObject);
    }

    public bool GetDead() {
        return isDead;
    }
}
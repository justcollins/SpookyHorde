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
    private Animator attackAnimation;

    public void Awake() {
        attackAnimation = GetComponentInChildren<Animator>();
    }

    public void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterHealth>();
    }

    public void SetTimer(float setTimer) {
        this.timer = setTimer;
    }

    void OnTriggerStay(Collider collider) {
        if (collider.gameObject.tag == "Player") {
            //this.attackAnimation.SetBool("Attack", true);
            this.attackAnimation.SetTrigger("Attack");
            player.setCurrentHealth(DealDamage(player.getCurrentHealth()));
        }// else {
            //this.attackAnimation.SetBool("Attack", false);
        //}
        
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

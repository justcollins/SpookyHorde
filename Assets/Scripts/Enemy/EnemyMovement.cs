using UnityEngine;
using System.Collections;

/*
Author: Justin Collins
Purpose of Script: Controls the enemie's movement
    */

public class EnemyMovement : MonoBehaviour {

    public int speed = 5;

    private GameObject player;
    private Animator moveAnimation;
    private NavMeshAgent navMesh;
    private EnemyHealth enemyHealth;

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        moveAnimation = gameObject.GetComponentInChildren<Animator>();
        navMesh = GetComponent<NavMeshAgent>();
        enemyHealth = GetComponent<EnemyHealth>();
        navMesh.speed = speed;
        moveAnimation.SetFloat("Speed", navMesh.speed);
        navMesh.stoppingDistance = 4.0f;
    }

    void OnEnable() {
        this.moveAnimation.SetFloat("Speed", navMesh.speed);
    }
	
	void Update () {
            ChasePlayer();
	}

    public void ChasePlayer() {
        navMesh.destination = player.transform.position;
        if(navMesh.remainingDistance == navMesh.stoppingDistance) {
            navMesh.speed = 0.0f;
            this.moveAnimation.SetFloat("Speed", navMesh.speed);
        }  else if (enemyHealth.GetDead()) {
            navMesh.speed = 0.0f;
            this.moveAnimation.SetFloat("Speed", navMesh.speed);
        } else {
            navMesh.speed = speed;
            this.moveAnimation.SetFloat("Speed", navMesh.speed);
        }
    }
}

using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    public int speed = 5;

    private GameObject player;
    private NavMeshAgent navMesh;

    void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        navMesh = GetComponent<NavMeshAgent>();
        navMesh.speed = speed;
    }
	
	void Update () {
        ChasePlayer();
	}

    public void ChasePlayer() {
        navMesh.destination = player.transform.position;
    }
}

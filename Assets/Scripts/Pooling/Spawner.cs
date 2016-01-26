using UnityEngine;
using System.Collections;

/*
Author: Justin Collins
Purpose of Script: To control the spawning of enemies and pick-ups throughout the scene
    */

public class Spawner : MonoBehaviour {

    public GameObject enemy;
    public GameObject[] pickUps;
    public GameObject[] enemySpawnPositions;
    public GameObject[] pickUpSpawnPositions;
    public int startingEnemies = 5;
    public int maxItems;
    public int enemySpawnTime = 10;
    public int itemSpawnTime = 40;
    public int maxWaves = 4;

    private float currentEnemySpawnTime;
    private float currentItemSpawnTime;
    private static int currentEnemies;
    private static int currentItems;
    private int currentWave;
    private int rando;
    private int randoObject;

	void Start () {
        currentEnemySpawnTime = enemySpawnTime;
        currentWave = 0;
	}

	void Update () {
        SpawnSystem();
	}

    void SpawnSystem() {
        if (currentWave < maxWaves) {
            if (enemySpawnTime <= currentEnemySpawnTime) {
                currentWave++;
                
                for (int i = 0; i < startingEnemies * currentWave; i++) {
                    rando = Random.Range(0, enemySpawnPositions.Length);
                    ObjectPooling.Spawn(enemy, enemySpawnPositions[rando].transform.position, enemySpawnPositions[rando].transform.rotation);
                    currentEnemies++;
                }
                currentEnemySpawnTime = 0.0f;
            }

            if (itemSpawnTime <= currentItemSpawnTime) {
                for (int i = currentItems; i < maxItems; i++) {
                    rando = Random.Range(0, pickUpSpawnPositions.Length);
                    randoObject = Random.Range(0, pickUps.Length);
                    ObjectPooling.Spawn(pickUps[randoObject], pickUpSpawnPositions[rando].transform.position, pickUpSpawnPositions[rando].transform.rotation);
                    currentItems++;
                }
                currentItemSpawnTime = 0.0f;
            }

            if (currentEnemies == 0) {
                currentEnemySpawnTime += Time.deltaTime;
            }

            if (currentItems < maxItems) {
                currentItemSpawnTime += Time.deltaTime;
            }
        }
    }

    public static void subtractCurrentEnemies(int subEnemies) {
        currentEnemies -= subEnemies;
    }

    public static void subtractCurrentItems(int subItems) {
        currentItems -= subItems;
    }
}

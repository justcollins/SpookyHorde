using UnityEngine;
using UnityEngine.UI;

public class SpawnerToGui : MonoBehaviour {

    public Text waveTimerText;

    private Spawner spawner;
    private float timeCounter;
    private int tempTimer;

	void Start () {
        waveTimerText.enabled = false;
        spawner = GetComponent<Spawner>();
        waveTimerText.enabled = false;
        timeCounter = 0.0f;
        tempTimer = spawner.enemySpawnTime;
	}
	
	void Update () {
        CheckSpawnTime();
	}

    public void CheckSpawnTime() {
        if (spawner.GetCurrentWave() < spawner.maxWaves) {
            if (spawner.GetCurrentEnemies() == 0) {
                waveTimerText.enabled = true;
                UpdateWaveTime();
            }
            else {
                waveTimerText.enabled = false;
                tempTimer = spawner.enemySpawnTime;
            }
        } else {
            waveTimerText.enabled = false;
        }
    }

    public void UpdateWaveTime() {
        timeCounter += Time.deltaTime;
        if (timeCounter >= 1) {
            tempTimer--;
            waveTimerText.text = "Next Wave in " + tempTimer.ToString() + " Seconds!";
            timeCounter = 0.0f;
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

/*
Author: Justin Collins
Purpose of Script: Displays all values that are needed to be on the GUI during gameplay
    */

public class ToGui : MonoBehaviour {

    public Text waveTimerText;
    public Shoot ammoRef;
    public Text ammoText;
    public Text healthText;
    public Slider healthSlider;
    public Text flareText;

    private CharacterHealth health;
    private CharacterInventory inventory;
    private Spawner spawner;
    private float timeCounter;
    private int tempTimer;

    void Awake() {
        
    }

    // Use this for initialization
    void Start () {
        health = GameObject.FindObjectOfType<CharacterHealth>();
        inventory = GameObject.FindObjectOfType<CharacterInventory>();
        spawner = GameObject.FindObjectOfType<Spawner>();
        SetTimer();
	}
	
	// Update is called once per frame
	void Update () {
        CheckSpawnTime();
        UpdateText();
    }

    public void SetTimer() {
        waveTimerText.enabled = false;
        waveTimerText.enabled = false;
        timeCounter = 0.0f;
        tempTimer = spawner.enemySpawnTime;
    }

    public void CheckSpawnTime()
    {
        if (spawner.GetCurrentWave() < spawner.maxWaves)
        {
            if (spawner.GetCurrentEnemies() == 0)
            {
                waveTimerText.enabled = true;
                UpdateWaveTime();
            }
            else {
                timeCounter = 0.0f;
                waveTimerText.enabled = false;
                tempTimer = spawner.enemySpawnTime;
            }
        }
        else {
            timeCounter = 0.0f;
            waveTimerText.enabled = false;
        }
    }

    public void UpdateWaveTime()
    {
        timeCounter += Time.deltaTime;
        if (timeCounter >= 1)
        {
            tempTimer--;
            waveTimerText.text = "Next Wave in " + tempTimer.ToString() + " Seconds!";
            timeCounter = 0.0f;
        }
    }

    private void UpdateText() {
        healthSlider.value = health.getCurrentHealth();
        healthText.text = health.getCurrentHealth().ToString() + "/" + health.health.ToString();
        ammoText.text = "Ammo: " + ammoRef.ammo.ToString();
        flareText.text = "Flares: " + inventory.getCurrentFlares().ToString();
    }
}

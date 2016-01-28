using UnityEngine;

/*
Author: Justin Collins
Purpose of Script: Controls the Health of the player and its interaction with the GUI in game
    */

public class CharacterHealth : MonoBehaviour {

    public int health = 100;

    private int currentHealth;
    private bool isDead;

    public int getCurrentHealth() {
        return currentHealth;
    }

    public void setCurrentHealth(int newHealth) {
        currentHealth = newHealth;
    }

    public void addCurrentHealth(int health) {
        currentHealth += health;
    }

    void Awake() {
        currentHealth = health;
        isDead = false;
    }
	
	void Update () {
        UpdateHealth();
	}

    void UpdateHealth() {
        isDead = DeadCheck();

        if (isDead) {
            Application.LoadLevel(0);
        }
    }

    public bool DeadCheck() {
        return (currentHealth <= 0);
    }
}

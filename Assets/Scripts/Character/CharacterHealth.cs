using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour {

    public int health = 100;
    public Text healthText;
    public Slider healthSlider;

    private int currentHealth;
    private bool isDead;

    void Awake() {
        currentHealth = health;
        healthSlider.maxValue = health;
        isDead = false;
    }
	
	void Update () {
        UpdateHealth();
	}

    void OnCollisionStay(Collision collider) {
        if(collider.gameObject.layer == 10) {
            currentHealth = collider.gameObject.GetComponent<EnemyAttack>().DealDamage(currentHealth);

        }
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.layer == 11) {
            Spawner.subtractCurrentItems(1);
            ObjectPooling.DeSpawn(collider.gameObject);
        }
    }

    void UpdateHealth() {
        healthSlider.value = currentHealth;
        sethealthText();
        isDead = DeadCheck();

        if (isDead) {
            Application.LoadLevel(0);
        }
    }

    public bool DeadCheck() {
        return (currentHealth <= 0);
    }

    public void sethealthText() {
        healthText.text = currentHealth.ToString() + "/" + health.ToString();
    }
}
